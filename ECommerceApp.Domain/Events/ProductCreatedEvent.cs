using ECommerceApp.Domain.Models;

namespace ECommerceApp.Domain.Events
{
    public class ProductCreatedEvent
    {
        public Product Product { get; private set; }

        public ProductCreatedEvent(Product product)
        {
            Product = product;
        }
    }
}