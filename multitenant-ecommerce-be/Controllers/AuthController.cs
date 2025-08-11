using Azure.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using multitenant_ecommerce_be.DTO;
using multitenant_ecommerce_be.Models;
using multitenant_ecommerce_be.Services.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace multitenant_ecommerce_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        public static User user = new();
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDTO request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null)
            {
                return BadRequest("Username already exits.");
            }
            var token = authService.CreateToken(user);
            Response.Cookies.Append("session", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });
            return Ok(new
            {
                user = new
                {
                    id = user.Id,
                    username = user.Username,
                    role = user.Role,
                }
            });
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var user = await authService.LoginAsync(request);
            if (user is null)
            {
                return BadRequest("Username already exits.");
            }
            var token = authService.CreateToken(user);
            if(token is null)
            {
                return BadRequest("Invail username or password");
            }

            Response.Cookies.Append("session", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });
            return Ok(
                new
                {
                    user = new
                    {
                        id = user.Id,
                        username = user.Username,
                        role = user.Role,
                    }
                });
        }
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("session");
            return Ok(new { message = "Logged out"});
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenticated");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-only")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are and admin");
        }
    }
}
