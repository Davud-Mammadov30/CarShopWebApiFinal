using CarShopWeb.Application.DTOs.CarModelDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface ICarModelService
    {
        Task<ResponseModel<List<GetCarModelDTO>>> GetAll();
        Task<ResponseModel<CreateCarModelDTO>> CreateCarModel(CreateCarModelDTO createCarModelDTO);
        Task<ResponseModel<bool>> UpdateCarModel(UpdateCarModelDTO updateCarModelDTO,int id);
        Task<ResponseModel<bool>> DeleteCarModel(int id);
        Task<ResponseModel<GetCarModelDTO>> GetCarModelByID(int id);
    }
}
