using AutoMapper;
using CarShopWeb.Application.DTOs.OrdersDTOs;
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
    public class OrdersService : IOrdersService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public OrdersService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel<CreateOrdersDTO>> CreateOrders(CreateOrdersDTO createOrdersDTO)
        {
            ResponseModel<CreateOrdersDTO> responseModel = new ResponseModel<CreateOrdersDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if (createOrdersDTO != null)
                {
                    var data = _mapper.Map<Orders>(createOrdersDTO);
                    await _unitofWork.GetRepositories<Orders>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if (rowsaffected > 0)
                    {
                        responseModel.Data = createOrdersDTO;
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

        public async Task<ResponseModel<bool>> DeleteOrders(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Orders>().GetByIdAsync(id);
                if (data != null)
                {
                    _unitofWork.GetRepositories<Orders>().Delete(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if (rowsaffected > 0)
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

        public async Task<ResponseModel<List<GetOrdersDTO>>> GetAll()
        {
            ResponseModel<List<GetOrdersDTO>> responseModel = new ResponseModel<List<GetOrdersDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var orders = await _unitofWork.GetRepositories<Orders>().GetAll().ToListAsync();
                var ordersDto = _mapper.Map<List<GetOrdersDTO>>(orders);
                responseModel.Data = ordersDto;
                responseModel.StatusCode = 200;
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<GetOrdersDTO>> GetOrdersById(int id)
        {
            ResponseModel<GetOrdersDTO> responseModel = new ResponseModel<GetOrdersDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Orders>().GetByIdAsync(id);
                if (data != null)
                {
                    var ordersDto = _mapper.Map<GetOrdersDTO>(data);
                    responseModel.Data = ordersDto;
                    responseModel.StatusCode = 200;
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

        public async Task<ResponseModel<bool>> UpdateOrders(UpdateOrdersDTO updateOrdersDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Orders>().GetByIdAsync(id);
                if (data != null)
                {
                    var order = _mapper.Map(updateOrdersDTO, data);
                    int rowsaffeted = await _unitofWork.SaveChangesAsync();
                    if (rowsaffeted > 0)
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
