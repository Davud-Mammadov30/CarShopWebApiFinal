using CarShopWeb.Application.DTOs.CarBrandDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface ICarBrandService
    {
        Task<ResponseModel<List<GetCarBrandDTO>>> GetAll();
        Task<ResponseModel<CreateCarBrandDTO>> CreateCarBrand(CreateCarBrandDTO createCarBrandDTO);
        Task<ResponseModel<bool>> UpdateCarBrand(UpdateCarBrandDTO updateCarBrandDTO,int id);
        Task<ResponseModel<bool>> DeleteCarBrand(int id);
        Task<ResponseModel<GetCarBrandDTO>> GetCarBrandByID(int id);
    }
}
