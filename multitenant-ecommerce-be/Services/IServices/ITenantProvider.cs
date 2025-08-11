namespace multitenant_ecommerce_be.Services.IServices
{
    public interface ITenantProvider
    {
        int? GetTenantId();
    }
}
