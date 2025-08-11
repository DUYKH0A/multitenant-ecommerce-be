using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Models;

namespace multitenant_ecommerce_be.Mapper
{
    public class ProductMapper
    {
        public static ProductDTO ToDTO(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = CategoryMapper.ToDTO(product.Category),
            };
        }
        public static List<ProductDTO> ToListDTO(List<Product> product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            return product.Select(p => ToDTO(p)).ToList();
        }
    }
}
