using CarShopWeb.Application.DTOs.CarsDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface ICarsService
    {
        Task<ResponseModel<List<GetCarsDTO>>> GetAll();
        Task<ResponseModel<CreateCarDTO>> CreateCars(CreateCarDTO createCarDTO);
        Task<ResponseModel<bool>> UpdateCars(UpdateCarsDTO updateCarsDTO,int id);
        Task<ResponseModel<bool>> DeleteCars(int id);
        Task<ResponseModel<GetCarsDTO>> GetCarsById(int id);
        Task<ResponseModel<List<GetCarsDTO>>> MostExpensiveCars();
    }
}
