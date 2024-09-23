using AutoMapper;
using CarShopWeb.Application.DTOs.CarModelDTOs;
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
    public class CarModelService : ICarModelService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public CarModelService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }

        public async Task<ResponseModel<CreateCarModelDTO>> CreateCarModel(CreateCarModelDTO createCarModelDTO)
        {
            ResponseModel<CreateCarModelDTO> responseModel = new ResponseModel<CreateCarModelDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if(createCarModelDTO != null)
                {
                    var data = _mapper.Map<CarModel>(createCarModelDTO);
                    await _unitofWork.GetRepositories<CarModel>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if (rowsaffected > 0)
                    {
                        responseModel.Data = createCarModelDTO;
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

        public async Task<ResponseModel<bool>> DeleteCarModel(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<CarModel>().GetByIdAsync(id);
                if(data != null)
                {
                    _unitofWork.GetRepositories<CarModel>().Delete(data);
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

        public async Task<ResponseModel<List<GetCarModelDTO>>> GetAll()
        {
            ResponseModel<List<GetCarModelDTO>> responseModel = new ResponseModel<List<GetCarModelDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var carModels = await _unitofWork.GetRepositories<CarModel>().GetAll().ToListAsync();
                var carModelDtos = _mapper.Map<List<GetCarModelDTO>>(carModels);
                responseModel.Data = carModelDtos;
                responseModel.StatusCode = 200;
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<GetCarModelDTO>> GetCarModelByID(int id)
        {
            ResponseModel<GetCarModelDTO> responseModel = new ResponseModel<GetCarModelDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<CarModel>().GetByIdAsync(id);
                if(data != null)
                {
                    var carModelDto = _mapper.Map<GetCarModelDTO>(data); 
                    responseModel.Data = carModelDto;
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

        public async Task<ResponseModel<bool>> UpdateCarModel(UpdateCarModelDTO updateCarModelDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<CarModel>().GetByIdAsync(id);
                if (data != null)
                {
                    var carModel = _mapper.Map(updateCarModelDTO,data);
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
    }
}
