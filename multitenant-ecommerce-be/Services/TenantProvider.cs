using multitenant_ecommerce_be.Services.IServices;

namespace multitenant_ecommerce_be.Services
{
    public class TenantProvider : ITenantProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TenantProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public int? GetTenantId()
        {
            var claim = _contextAccessor.HttpContext?.User?.FindFirst("tenant_id")?.Value;
            if(int.TryParse(claim, out var tenantId)) { return tenantId; }
            return null;
        }

    }
}
