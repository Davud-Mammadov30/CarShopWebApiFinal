using CarShopWeb.Application.DTOs.ContactTypeDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : ControllerBase
    {
        private readonly IContactTypeService _contactTypeService;
        public ContactTypeController(IContactTypeService contactTypeService)
        {
            _contactTypeService = contactTypeService;
        }
        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var response =await _contactTypeService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactTypeDTO createContactTypeDTO)
        {
            var response = await _contactTypeService.CreateContact(createContactTypeDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _contactTypeService.DeleteContact(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(CreateContactTypeDTO updateContactDTO, int id)
        {
            var response = await _contactTypeService.UpdateContact(updateContactDTO, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _contactTypeService.GetContactById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
