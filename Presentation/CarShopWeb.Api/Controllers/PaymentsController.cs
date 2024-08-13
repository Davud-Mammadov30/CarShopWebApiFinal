using CarShopWeb.Application.DTOs.CarsDTOs;
using CarShopWeb.Application.DTOs.PaymentsDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentsService _paymentsService;
        public PaymentsController(IPaymentsService paymentsService)
        {
            _paymentsService = paymentsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _paymentsService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentsDTO createPaymentsDTO)
        {
            var response = await _paymentsService.CreatePayments(createPaymentsDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _paymentsService.DeletePayments(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdatePaymentsDTO updatePaymentsDTO, int id)
        {
            var response = await _paymentsService.UpdatePayments(updatePaymentsDTO, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _paymentsService.GetPaymentsById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
