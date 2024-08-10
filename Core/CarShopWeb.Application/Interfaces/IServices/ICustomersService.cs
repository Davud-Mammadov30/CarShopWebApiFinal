using CarShopWeb.Application.DTOs.CustomersDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface ICustomersService
    {
        Task<ResponseModel<List<CustomersGetDTO>>> GetAll();
        Task<ResponseModel<CustomersCreateDTO>> CreateCustomers(CustomersCreateDTO customersCreateDTO);
        Task<ResponseModel<bool>> UpdateCustomers(CustomersUpdateDTO customersUpdateDTO,int id);
        Task<ResponseModel<bool>> DeleteCustomers(int id);
        Task<ResponseModel<CustomersGetDTO>> GetCustomersById(int id);

    }
}
