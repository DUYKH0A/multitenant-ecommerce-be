using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using multitenant_ecommerce_be.Data;
using multitenant_ecommerce_be.Mapper;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.Services.IServices;
using multitenant_ecommerce_be.DTO;
using Microsoft.AspNetCore.Authorization;

namespace multitenant_ecommerce_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;
        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategories()
        {
            var dto = await _services.GetCategories();
            return Ok(dto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            var dto = await _services.GetCategory(id);
            if (dto is null)
            {
                return NotFound();
            }
            return Ok(dto);
        }   
        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(CategoryDTO dto)
        {
            var category = await _services.CreateCategory(dto);
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, [FromBody] CategoryDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Category ID mismatch");
            }
            var updated = await _services.UpdateCategory(id,dto);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _services.DeleteCategory(id);
            if (!category)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
