using AutoMapper;
using CarShopWeb.Application.DTOs.CarBrandDTOs;
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
    public class CarBrandService : ICarBrandService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public CarBrandService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel<CreateCarBrandDTO>> CreateCarBrand(CreateCarBrandDTO createCarBrandDTO)
        {
            ResponseModel<CreateCarBrandDTO> response = new ResponseModel<CreateCarBrandDTO>()
            {
                Data = null,
                StatusCode = 400,
            };
            try
            {
                if(createCarBrandDTO != null)
                {
                    var data = _mapper.Map<CarBrand>(createCarBrandDTO);
                    await _unitofWork.GetRepositories<CarBrand>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        response.Data = createCarBrandDTO;
                        response.StatusCode = 200;
                    }
                    else
                    {
                        response.StatusCode = 500;
                    }
                }
            }
            catch 
            {
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<ResponseModel<bool>> DeleteCarBrand(int id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<CarBrand>().GetByIdAsync(id);
                if(data != null)
                {
                    _unitofWork.GetRepositories<CarBrand>().Delete(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        response.Data = true;
                        response.StatusCode = 200;
                    }
                    else 
                    { 
                        response.StatusCode = 500;
                    }
                }
            }
            catch 
            {
                response.StatusCode = 500; 
            }
            return response;
        }

        public async Task<ResponseModel<List<GetCarBrandDTO>>> GetAll()
        {
            ResponseModel<List<GetCarBrandDTO>> response = new ResponseModel<List<GetCarBrandDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var carBrands = await _unitofWork.GetRepositories<CarBrand>().GetAll().ToListAsync();
                var carBrandDtos = _mapper.Map<List<GetCarBrandDTO>>(carBrands);
                response.Data = carBrandDtos;
                response.StatusCode = 200;
            }
            catch 
            {
                response.StatusCode = 500;
            }
            return response;
        }

        public async Task<ResponseModel<GetCarBrandDTO>> GetCarBrandByID(int id)
        {
            ResponseModel<GetCarBrandDTO> response = new ResponseModel<GetCarBrandDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<CarBrand>().GetByIdAsync(id);
                if(data != null)
                {
                    var carBrandDto = _mapper.Map<GetCarBrandDTO>(data);
                    response.Data = carBrandDto;
                    response.StatusCode = 200;
                }
                else
                {
                    response.StatusCode = 500;
                }
            }
            catch 
            {
                response.StatusCode = 500; 
            }
            return response;
        }

        public async Task<ResponseModel<bool>> UpdateCarBrand(UpdateCarBrandDTO updateCarBrandDTO, int id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<CarBrand>().GetByIdAsync(id);
                if(data != null)
                {
                    var carBrand = _mapper.Map(updateCarBrandDTO, data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        response.Data = true;
                        response.StatusCode = 200;
                    }
                    else
                    {
                        response.StatusCode = 500;
                    }
                }
            }
            catch
            {
                response.StatusCode = 500;
            }
            return response;
        }
    }
}
