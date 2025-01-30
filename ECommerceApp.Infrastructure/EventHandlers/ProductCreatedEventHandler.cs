using MassTransit;
using ECommerceApp.Domain.Events;

namespace ECommerceApp.Infrastructure.EventHandlers
{
    public class ProductCreatedEventHandler : IConsumer<ProductCreatedEvent>
    {
        public Task Consume(ConsumeContext<ProductCreatedEvent> context)
        {
            var product = context.Message.Product;
            Console.WriteLine($"Product Created: {product.Name}");

            return Task.CompletedTask;
        }
    }
}