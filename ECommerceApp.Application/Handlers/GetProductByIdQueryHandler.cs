using ECommerceApp.Application.DTOs;
using ECommerceApp.Infrastructure.Data;
using ECommerceApp.Application.Queries;

namespace ECommerceApp.Application.Handlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly ApplicationDbContext _context;

        public GetProductByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if (product == null)
            {
                return null;
            }

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                PriceAmount = product.Price.Amount,
                PriceCurrency = product.Price.Currency,
                Stock = product.Stock
            };
        }
    }
}