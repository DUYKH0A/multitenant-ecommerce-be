using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using multitenant_ecommerce_be.Data;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Services.IServices;

namespace multitenant_ecommerce_be.Controllers.Vendor
{
    [Route("api/vendor/[controller]")]
    [ApiController]
    [Authorize(Roles ="vendor")]
    public class ProductController : ControllerBase
    {
        public readonly IVendorProductServices _Services;
        public ProductController(IVendorProductServices Services)
        {
            _Services = Services;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts() 
            {
            var products = await _Services.GetProducts();
            return Ok(products);
            }
    }
}
