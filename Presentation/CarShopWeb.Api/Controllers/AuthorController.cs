using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> LoginAsync(string userNameOrEmail, string password)
        {
            var data = await _authorService.LoginAsync(userNameOrEmail, password);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> LoginWithRefreshTokenAsync(string refreshToken)
        {
            var data = await _authorService.LoginWithRefreshTokenAsync(refreshToken);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> LogOut(string userNameorEmail)
        {
            var data = await _authorService.LogOut(userNameorEmail);
            return StatusCode(data.StatusCode, data);
        }
        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> PasswordResetAsync(string userNameorEmail, string currentpas, string newpas)
        {
            var data = await _authorService.PasswordResetAsync(userNameorEmail, currentpas, newpas);
            return Ok(data);
        }
    }
}
