using CarShopWeb.Application.DTOs.FeaturesDTOs;
using CarShopWeb.Application.DTOs.OrdersDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShopWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeaturesService _featuresService;
        public FeaturesController(IFeaturesService featuresService)
        {
            _featuresService = featuresService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _featuresService.GetAll();
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateFeaturesDTO createFeaturesDTO)
        {
            var response = await _featuresService.CreateFeatures(createFeaturesDTO);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _featuresService.DeleteFeatures(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeaturesDTO updateFeaturesDTO, int id)
        {
            var response = await _featuresService.UpdateFeatures(updateFeaturesDTO, id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _featuresService.GetFeaturesById(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
