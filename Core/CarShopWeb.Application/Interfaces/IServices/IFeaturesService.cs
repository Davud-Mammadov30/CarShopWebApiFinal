using CarShopWeb.Application.DTOs.FeaturesDTOs;
using CarShopWeb.Application.DTOs.OrdersDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface IFeaturesService
    {
        Task<ResponseModel<List<GetFeaturesDTO>>> GetAll();
        Task<ResponseModel<CreateFeaturesDTO>> CreateFeatures(CreateFeaturesDTO createFeaturesDTO);
        Task<ResponseModel<bool>> UpdateFeatures(UpdateFeaturesDTO updateFeaturesDTO, int id);
        Task<ResponseModel<bool>> DeleteFeatures(int id);
        Task<ResponseModel<GetFeaturesDTO>> GetFeaturesById(int id); 
    }
}
