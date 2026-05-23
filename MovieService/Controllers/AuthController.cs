using Microsoft.AspNetCore.Mvc;

namespace MovieService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new()
        {
            new User
            {
                Email = "admin@films.lt",
                Password = "admin123",
                Role = "ADMIN"
            },
            new User
            {
                Email = "user@films.lt",
                Password = "user123",
                Role = "USER"
            }
        };

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = users.FirstOrDefault(u =>
                u.Email == request.Email &&
                u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password"
                });
            }

            return Ok(new
            {
                message = "Login successful",
                email = user.Email,
                role = user.Role
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class User
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}