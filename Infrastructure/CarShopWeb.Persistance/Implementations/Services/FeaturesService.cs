using AutoMapper;
using CarShopWeb.Application.DTOs.FeaturesDTOs;
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
    public class FeaturesService : IFeaturesService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public FeaturesService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel<CreateFeaturesDTO>> CreateFeatures(CreateFeaturesDTO createFeaturesDTO)
        {
            ResponseModel<CreateFeaturesDTO> responseModel = new ResponseModel<CreateFeaturesDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if(createFeaturesDTO != null)
                {
                    var data = _mapper.Map<Features>(createFeaturesDTO);
                    await _unitofWork.GetRepositories<Features>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        responseModel.Data = createFeaturesDTO;
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

        public async Task<ResponseModel<bool>> DeleteFeatures(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Features>().GetByIdAsync(id);
                if(data != null)
                {
                    _unitofWork.GetRepositories<Features>().Delete(data);
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

        public async Task<ResponseModel<List<GetFeaturesDTO>>> GetAll()
        {
            ResponseModel<List<GetFeaturesDTO>> responseModel = new ResponseModel<List<GetFeaturesDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Features>().GetAll().ToListAsync();
                if(data != null)
                {
                    var features = _mapper.Map<List<GetFeaturesDTO>>(data);
                    responseModel.Data = features;
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

        public async Task<ResponseModel<GetFeaturesDTO>> GetFeaturesById(int id)
        {
            ResponseModel<GetFeaturesDTO> responseModel = new ResponseModel<GetFeaturesDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Features>().GetByIdAsync(id);
                if(data != null)
                {
                    var feature = _mapper.Map<GetFeaturesDTO>(data);
                    responseModel.Data = feature;
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

        public async Task<ResponseModel<bool>> UpdateFeatures(UpdateFeaturesDTO updateFeaturesDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Features>().GetByIdAsync(id);
                if(data != null)
                {
                    _mapper.Map(updateFeaturesDTO,data);
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
