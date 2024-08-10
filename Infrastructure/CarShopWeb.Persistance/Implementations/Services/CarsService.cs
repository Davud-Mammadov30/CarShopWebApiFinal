using AutoMapper;
using CarShopWeb.Application.DTOs.CarsDTOs;
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

namespace CarShopWeb.Persistence.Implementations.Services
{
    public class CarsService : ICarsService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public CarsService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel<CreateCarDTO>> CreateCars(CreateCarDTO createCarDTO)
        {
            var responseModel = new ResponseModel<CreateCarDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if (createCarDTO != null)
                {
                    var data = _mapper.Map<Cars>(createCarDTO);
                    await _unitofWork.GetRepositories<Cars>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        responseModel.Data = createCarDTO;
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

        public async Task<ResponseModel<bool>> DeleteCars(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>() 
            {
                Data = false,
                StatusCode=400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Cars>().GetByIdAsync(id);
                if(data != null)
                {
                    _unitofWork.GetRepositories<Cars>().Delete(data);
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
                responseModel.StatusCode=500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<GetCarsDTO>>> GetAll()
        {
            ResponseModel<List<GetCarsDTO>> responseModel = new ResponseModel<List<GetCarsDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var cars = await _unitofWork.GetRepositories<Cars>().GetAll().ToListAsync();
                var carsDtos = _mapper.Map<List<GetCarsDTO>>(cars);
                responseModel.Data = carsDtos;
                responseModel.StatusCode = 200;
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<GetCarsDTO>> GetCarsById(int id)
        {
            ResponseModel<GetCarsDTO> responseModel = new ResponseModel<GetCarsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Cars>().GetByIdAsync(id);
                if(data != null)
                {
                    var carsDto = _mapper.Map<GetCarsDTO>(data);
                    responseModel.Data = carsDto;
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

        public async Task<ResponseModel<bool>> UpdateCars(UpdateCarsDTO updateCarsDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Cars>().GetByIdAsync(id);
                if(data != null)
                {
                    var car = _mapper.Map(updateCarsDTO,data);
                    int rowaffected = await _unitofWork.SaveChangesAsync();
                    if(rowaffected > 0) 
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
                    }
                    else { responseModel.StatusCode = 500; }
                }
            }
            catch (Exception ex)
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}
