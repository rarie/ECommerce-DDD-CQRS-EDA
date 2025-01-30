using ECommerceApp.Domain.ValueObjects;

namespace ECommerceApp.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Money Price { get; set; }
        public int Stock { get; set; }

    }
}