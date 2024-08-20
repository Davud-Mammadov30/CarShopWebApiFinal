using CarShopWeb.Application.DTOs.CarsDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;
        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _carsService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDTO createCarDTO)
        {
            var response = await _carsService.CreateCars(createCarDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete] 
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _carsService.DeleteCars(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut] 
        public async Task<IActionResult> Update(UpdateCarsDTO updateCarsDTO, int id)
        {
            var response = await _carsService.UpdateCars(updateCarsDTO, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _carsService.GetCarsById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
