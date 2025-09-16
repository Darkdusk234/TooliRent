using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TooliRent.Core.Models;
using TooliRent.Services.DTOs.AuthDtos;

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

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                BirthDate = registerDto.BirthDate
            };

            var result = await _users.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _users.FindByNameAsync(loginDto.UserName);

            if (user == null || !await _users.CheckPasswordAsync(user, loginDto.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = await GenerateJwtTokenAsync(user);
            return Ok(new { token });
        }

        private async Task<string> GenerateJwtTokenAsync(IdentityUser user)
        {
            var jwt = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _users.GetRolesAsync(user);           // <-- fetch roles
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

            var claims = new List<Claim>
             {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            claims.AddRange(roleClaims);

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwt["ExpiresInMinutes"]!)),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
