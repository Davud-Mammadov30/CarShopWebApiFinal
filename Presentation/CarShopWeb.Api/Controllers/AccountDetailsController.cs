using CarShopWeb.Application.DTOs.AccountDetailDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly IAccountDetailService _accountDetailService;
        public AccountDetailsController(IAccountDetailService accountDetailService)
        {
            _accountDetailService = accountDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _accountDetailService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost] 
        public async Task<IActionResult> Create(CreateAccountDetailDTO accountDetailDTO)
        {
            var response = await _accountDetailService.CreateAccount(accountDetailDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete] 
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _accountDetailService.DeleteAccount(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut] 
        public async Task<IActionResult> Update(UpdateAccountDetailDTO accountDetailDTO, int id)
        {
            var response = await _accountDetailService.UpdateAccount(accountDetailDTO,id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _accountDetailService.GetAccountById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
