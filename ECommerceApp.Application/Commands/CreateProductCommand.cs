namespace ECommerceApp.Application.Commands
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public decimal PriceAmount { get; set; }
        public string PriceCurrency { get; set; }
        public int Stock { get; set; }
    }
}