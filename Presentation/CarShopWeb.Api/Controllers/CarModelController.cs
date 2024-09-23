using CarShopWeb.Application.DTOs.CarBrandDTOs;
using CarShopWeb.Application.DTOs.CarModelDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Persistence.Implementations.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : ControllerBase
    {
        private readonly ICarModelService _modelService;
        public CarModelController(ICarModelService modelService)
        {
            _modelService = modelService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _modelService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCarModelDTO createCarModelDTO)
        {
            var response = await _modelService.CreateCarModel(createCarModelDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _modelService.DeleteCarModel(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateCarModelDTO updateCarModelDTO, int id)
        {
            var response = await _modelService.UpdateCarModel(updateCarModelDTO, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _modelService.GetCarModelByID(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
