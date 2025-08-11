using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Models;

namespace multitenant_ecommerce_be.Services.IServices
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO user);
        Task<User?> LoginAsync(UserDTO user);
        string CreateToken(User user);


    }
}
