using CarShopWeb.Application.DTOs.CustomersDTOs;
using CarShopWeb.Application.DTOs.FeaturesDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;
        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customersService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomersCreateDTO customersCreateDTO)
        {
            var response = await _customersService.CreateCustomers(customersCreateDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _customersService.DeleteCustomers(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCustomers(CustomersUpdateDTO customersUpdateDTO, int id)
        {
            var response = await _customersService.UpdateCustomers(customersUpdateDTO, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _customersService.GetCustomersById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
