using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TooliRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _users;    // or your IUserService
        private readonly IConfiguration _config;

        public AuthController(UserManager<IdentityUser> users, IConfiguration config)
        {
            _users = users;
            _config = config;
        }
    }
}
