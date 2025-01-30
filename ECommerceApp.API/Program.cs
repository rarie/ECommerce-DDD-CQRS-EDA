using ECommerceApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MassTransit;
using ECommerceApp.Infrastructure.EventHandlers;
using ECommerceApp.Infrastructure.Configurations;
using ECommerceApp.Application.Handlers;


var builder = WebApplication.CreateBuilder(args);
var rabbitMQSettings = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<ProductCreatedEventHandler>();
    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitMQSettings.Host, rabbitMQSettings.VirtualHost, h =>
        {
            h.Username(rabbitMQSettings.Username);
            h.Password(rabbitMQSettings.Password);
        });

        cfg.ReceiveEndpoint(rabbitMQSettings.Endpoint, e =>
        {
            e.ConfigureConsumer<ProductCreatedEventHandler>(context);
        });
    });
});

builder.Services.AddScoped<CreateProductCommandHandler>();
builder.Services.AddScoped<GetProductByIdQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();