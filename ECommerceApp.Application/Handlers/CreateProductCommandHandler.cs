using MassTransit;
using ECommerceApp.Domain.Models;
using ECommerceApp.Domain.ValueObjects;
using ECommerceApp.Domain.Events;
using ECommerceApp.Infrastructure.Data;
using ECommerceApp.Application.Commands;

namespace ECommerceApp.Application.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly ApplicationDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;

        public CreateProductCommandHandler(ApplicationDbContext context, IPublishEndpoint publishEndpoint)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var price = new Money(request.PriceAmount, request.PriceCurrency);
            var product = new Product
            {
                Name = request.Name,
                Price = price,
                Stock = request.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);
            await _publishEndpoint.Publish(new ProductCreatedEvent(product), cancellationToken);

            return product.Id;
        }
    }
}