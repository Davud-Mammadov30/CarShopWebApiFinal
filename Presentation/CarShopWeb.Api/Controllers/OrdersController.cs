using CarShopWeb.Application.DTOs.OrdersDTOs;
using CarShopWeb.Application.DTOs.PaymentsDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _ordersService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrdersDTO createOrdersDTO)
        {
            var response = await _ordersService.CreateOrders(createOrdersDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _ordersService.DeleteOrders(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrdersDTO updateOrdersDTO, int id)
        {
            var response = await _ordersService.UpdateOrders(updateOrdersDTO, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _ordersService.GetOrdersById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
