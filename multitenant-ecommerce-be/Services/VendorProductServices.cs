using Microsoft.EntityFrameworkCore;
using multitenant_ecommerce_be.Data;
using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Mapper;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.Services.IServices;

namespace multitenant_ecommerce_be.Services
{
    public class VendorProductServices : IVendorProductServices
    {
        private readonly MultitenantEcommerceContext _context;
        private readonly ITenantProvider _tenantProvider;
        public VendorProductServices(MultitenantEcommerceContext context, ITenantProvider tenantProvider)
        {
            _tenantProvider = tenantProvider;
            _context = context;
        }
        public async Task<List<ProductDTO>> GetProducts()
        {
            var Products = await _context.Products
                .Where(p => p.TenantId == _tenantProvider.GetTenantId())
                .Include(p => p.Category)
                .ToListAsync();
            var ProductsDTO = ProductMapper.ToListDTO(Products);
            return ProductsDTO;
        }
        public async Task<Product?> GetProductById(int productId)
        {
            var Product = await _context.Products
                 .Where(p => p.TenantId == _tenantProvider.GetTenantId())
                 .FirstOrDefaultAsync(c => c.Id == productId);
            if (Product is null) 
            {
                return null;
            }
            return Product;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            product.TenantId = _tenantProvider.GetTenantId() ?? throw new InvalidOperationException("Tenant ID is required.");
            var productCreated = _context.Products.Add(product).Entity;
            await _context.SaveChangesAsync();
            return productCreated;
        }
    }
}
