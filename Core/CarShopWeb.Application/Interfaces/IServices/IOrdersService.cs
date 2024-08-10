using CarShopWeb.Application.DTOs.OrdersDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface IOrdersService
    {
        Task<ResponseModel<List<GetOrdersDTO>>> GetAll();
        Task<ResponseModel<CreateOrdersDTO>> CreateOrders(CreateOrdersDTO createOrdersDTO);
        Task<ResponseModel<bool>> UpdateOrders(UpdateOrdersDTO updateOrdersDTO,int id);
        Task<ResponseModel<bool>> DeleteOrders(int id);
        Task<ResponseModel<GetOrdersDTO>> GetOrdersById(int id);
    }
}
