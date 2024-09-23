using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Application.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _roleService.GetAllroles();
            return StatusCode(response.StatusCode,response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            var response = await _roleService.CreateRole(name);
            return StatusCode(response.StatusCode,response);
        }
        [HttpDelete] 
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _roleService.DeleteRole(id);
            return StatusCode(response.StatusCode,response);
        }
        [HttpPut] 
        public async Task<IActionResult> Update(string id, string name)
        {
            var response = await _roleService.UpdateRole(id,name);
            return StatusCode(response.StatusCode,response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _roleService.GetRoleById(id);
            return StatusCode(response.StatusCode,response);
        }

    }
}
