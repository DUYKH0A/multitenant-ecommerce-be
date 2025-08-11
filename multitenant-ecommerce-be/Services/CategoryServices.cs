using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using multitenant_ecommerce_be.Data;
using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Mapper;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.Services.IServices;

namespace multitenant_ecommerce_be.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly MultitenantEcommerceContext _context;

        public CategoryServices(MultitenantEcommerceContext context)
        {   
            _context = context;
        }
        public async Task<List<CategoryDTO>> GetCategories()
        {
            var rootCategories = await _context.Categories
                .Where(c => c.ParentId == null)
                .Include(c => c.SubCategories)
                .ToListAsync();
            var dto = CategoryMapper.ToListDTO(rootCategories);
            return dto;
        }
        public async Task<CategoryDTO?> GetCategory(int id)
        {            
            var category = await _context.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                return null;
            }
            var dto = CategoryMapper.ToDTO(category);
            return dto;
        }
        public async Task<Category> CreateCategory(CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                throw new ArgumentNullException(nameof(categoryDTO));
            }
            var category = CategoryMapper.ToEntity(categoryDTO);
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
        public async Task<bool> UpdateCategory(int id, CategoryDTO dto)
        {
            if (id != dto.Id)
            {
                return false; 
            }

            var Category = await _context.Categories.FindAsync(id);
            if (Category == null)
            {
                return false;
            }
            Category.Name = dto.Name;
            Category.Slug = dto.Slug;
            Category.Color = dto.Color;
            Category.ParentId = dto.ParentId;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
