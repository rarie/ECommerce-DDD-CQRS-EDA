using Microsoft.AspNetCore.Mvc;
using ECommerceApp.Application.Commands;
using ECommerceApp.Application.Queries;
using ECommerceApp.Application.Handlers;

namespace ECommerceApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;

        public ProductController(CreateProductCommandHandler createProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var productId = await _createProductCommandHandler.Handle(command, CancellationToken.None);

            return Ok(productId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var query = new GetProductByIdQuery { Id = id };
            var productDto = await _getProductByIdQueryHandler.Handle(query);

            if (productDto == null)
            {
                return NotFound();
            }

            return Ok(productDto);
        }
    }
}