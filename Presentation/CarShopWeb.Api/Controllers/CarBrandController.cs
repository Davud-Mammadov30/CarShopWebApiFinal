using CarShopWeb.Application.DTOs.CarBrandDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandController : ControllerBase
    {
        private readonly ICarBrandService _carBrandService;
        public CarBrandController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> GetAll() 
        {
            var response = await _carBrandService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCarBrandDTO createCarBrandDTO)
        {
            var response = await _carBrandService.CreateCarBrand(createCarBrandDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carBrandService.DeleteCarBrand(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateCarBrandDTO updateCarBrandDTO,int id)
        {
            var response = await _carBrandService.UpdateCarBrand(updateCarBrandDTO,id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _carBrandService.GetCarBrandByID(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
