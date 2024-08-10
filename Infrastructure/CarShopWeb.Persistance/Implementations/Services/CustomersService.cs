using AutoMapper;
using CarShopWeb.Application.DTOs.CustomersDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Application.Interfaces.IUnitofworks;
using CarShopWeb.Application.Models;
using CarShopWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Infrastructure.Implementations.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public CustomersService(IUnitofwork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        public async Task<ResponseModel<CustomersCreateDTO>> CreateCustomers(CustomersCreateDTO customersCreateDTO)
        {
            ResponseModel<CustomersCreateDTO> responseModel = new ResponseModel<CustomersCreateDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if(customersCreateDTO != null)
                {
                    var data = _mapper.Map<Customers>(customersCreateDTO);
                    await _unitofWork.GetRepositories<Customers>().AddAsync(data);
                    int rowsAffected = await _unitofWork.SaveChangesAsync();
                    if(rowsAffected > 0)
                    {
                        responseModel.Data = customersCreateDTO;
                        responseModel.StatusCode = 200;
                    }
                    else
                    {
                        responseModel.StatusCode = 500;
                    }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> DeleteCustomers(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Customers>().GetByIdAsync(id);
                if(data != null)
                {
                    _unitofWork.GetRepositories<Customers>().Delete(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        responseModel.Data = true; 
                        responseModel.StatusCode = 200;
                    }
                    else
                    {
                        responseModel.StatusCode = 500;
                    }
                }
            }
            catch 
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<CustomersGetDTO>>> GetAll()
        {
            ResponseModel<List<CustomersGetDTO>> responseModel = new ResponseModel<List<CustomersGetDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var customers = await _unitofWork.GetRepositories<Customers>().GetAll().ToListAsync();
                var customersDto = _mapper.Map<List<CustomersGetDTO>>(customers);
                responseModel.Data = customersDto;
                responseModel.StatusCode=200;
                
            }
            catch 
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<CustomersGetDTO>> GetCustomersById(int id)
        {
            ResponseModel<CustomersGetDTO> responseModel = new ResponseModel<CustomersGetDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Customers>().GetByIdAsync(id);
                if (data != null)
                {
                    var customersDto = _mapper.Map<CustomersGetDTO>(data);
                    responseModel.Data = customersDto;
                    responseModel.StatusCode=200;
                }
                else
                {
                    responseModel.StatusCode = 500;
                }
            }
            catch 
            {
                responseModel.StatusCode = 500; 
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> UpdateCustomers(CustomersUpdateDTO customersUpdateDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Customers>().GetByIdAsync(id);
                if (data != null)
                {
                    var customers = _mapper.Map(customersUpdateDTO,data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
                    }
                    else
                    {
                        responseModel.StatusCode = 500;
                    }
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}
