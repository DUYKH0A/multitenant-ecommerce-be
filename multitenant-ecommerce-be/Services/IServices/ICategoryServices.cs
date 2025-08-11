using Microsoft.AspNetCore.Mvc;
using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Models;

namespace multitenant_ecommerce_be.Services.IServices
{
    public interface ICategoryServices
    {
        Task<List<CategoryDTO>> GetCategories();
        Task<CategoryDTO?> GetCategory(int id);
        Task<Category> CreateCategory(CategoryDTO categoryDTO);
        Task<bool> UpdateCategory(int id, CategoryDTO categoryDTO);
        Task<bool> DeleteCategory(int id);

    }
}
