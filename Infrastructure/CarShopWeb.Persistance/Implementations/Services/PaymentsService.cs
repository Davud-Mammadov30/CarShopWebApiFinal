using AutoMapper;
using CarShopWeb.Application.DTOs.PaymentsDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Application.Interfaces.IUnitofworks;
using CarShopWeb.Application.Models;
using CarShopWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Infrastructure.Implementations.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public PaymentsService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel<CreatePaymentsDTO>> CreatePayments(CreatePaymentsDTO createPaymentsDTO)
        {
            ResponseModel<CreatePaymentsDTO> responseModel = new ResponseModel<CreatePaymentsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if(createPaymentsDTO != null)
                {
                    var data = _mapper.Map<Payments>(createPaymentsDTO);
                    await _unitofWork.GetRepositories<Payments>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        responseModel.Data = createPaymentsDTO;
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

        public async Task<ResponseModel<bool>> DeletePayments(int id)
        {
            ResponseModel<CreatePaymentsDTO> responseModel = new ResponseModel<CreatePaymentsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Payments>().GetByIdAsync(id);
                if(data != null)
                {
                    _mapper.Map<Payments>(data);
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public Task<ResponseModel<List<GetPaymentsDTO>>> GetAll()
        {
            ResponseModel<CreatePaymentsDTO> responseModel = new ResponseModel<CreatePaymentsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {

            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public Task<ResponseModel<GetPaymentsDTO>> GetPaymentsById(int id)
        {
            ResponseModel<CreatePaymentsDTO> responseModel = new ResponseModel<CreatePaymentsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {

            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public Task<ResponseModel<bool>> UpdatePayments(UpdatePaymentsDTO updatePaymentsDTO, int id)
        {
            ResponseModel<CreatePaymentsDTO> responseModel = new ResponseModel<CreatePaymentsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {

            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}
