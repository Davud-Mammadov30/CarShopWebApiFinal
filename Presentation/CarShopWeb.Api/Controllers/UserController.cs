using CarShopWeb.Application.DTOs.UsersDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAllUsersAsync();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDTO model)
        {
            var response = await _userService.CreateAsync(model);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string userIOorName)
        {
            var response = await _userService.DeleteUserAsync(userIOorName);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateDTO model)
        {
            var response = await _userService.UpdateUserAsync(model);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRolesToUser(string userIdOrName)
        {
            var response = await _userService.GetRolesToUserAsync(userIdOrName);
            return StatusCode(response.StatusCode, response);
        }

    }
}
