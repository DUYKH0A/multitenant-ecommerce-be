using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Models;
using System.Drawing;

namespace multitenant_ecommerce_be.Mapper
{
    public class CategoryMapper
    {
        public static CategoryDTO ToDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                Color = category.Color,
                ParentId = category.ParentId,
                SubCategories = category.SubCategories?.Select(sub => new CategoryDTO
                {
                    Id = sub.Id,
                    Name = sub.Name,
                    Slug = sub.Slug,
                    Color = sub.Color,
                    ParentId = sub.ParentId,
                    SubCategories = new List<CategoryDTO>()
                }).ToList() ?? new List<CategoryDTO>()
            };
        }

        public static List<CategoryDTO> ToListDTO(List<Category> rootCategories)
        {
            return rootCategories.Select(c => ToDTO(c)).ToList();
        }

        public static Category ToEntity(CategoryDTO dto)
        {
            return new Category
            {
                Name = dto.Name,
                Slug = dto.Slug,
                Color = dto.Color,
                ParentId = dto.ParentId
            };
        }

    }
}

