using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.Services.IServices;

namespace multitenant_ecommerce_be.Controllers.Public
{
    [Route("api/public/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IPublicProductServices _Services;
        public ProductController(IPublicProductServices publicProductServices)
        {
            _Services = publicProductServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _Services.GetProducts();
            return Ok(products);
        }
        [HttpGet("slug")]
        public async Task<ActionResult<List<Product>>> GetProductsBySlug([FromQuery] string categorySlug, [FromQuery] string? subcategorySlug)
        {
            var products = await _Services.GetProductBySlug(categorySlug, subcategorySlug);
            return Ok(products);
        }
    }
}
