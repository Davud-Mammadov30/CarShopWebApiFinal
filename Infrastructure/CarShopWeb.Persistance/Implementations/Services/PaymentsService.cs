using AutoMapper;
using CarShopWeb.Application.DTOs.PaymentsDTOs;
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
                var order = await _unitofWork.GetRepositories<Orders>()
                    .GetByIdAsync(createPaymentsDTO.OrderID);

                if (order == null)
                {
                    responseModel.StatusCode = 404;
                    return responseModel;
                }

                // Ensure the payment amount matches the total order price
                if (createPaymentsDTO.PaymentAmount != order.TotalPrice)
                {
                    responseModel.StatusCode = 400; // Payment amount mismatch
                    return responseModel;
                }

                // Deduct money from customer's account
                var customerAccount = await _unitofWork.GetRepositories<AccountDetail>()
                    .Table
                    .FirstOrDefaultAsync(acc => acc.CustomerID == order.CustomerID);

                if (customerAccount != null && customerAccount.Money >= createPaymentsDTO.PaymentAmount)
                {
                    customerAccount.Money -= createPaymentsDTO.PaymentAmount;

                    // Create payment record
                    var payment = _mapper.Map<Payments>(createPaymentsDTO);
                    await _unitofWork.GetRepositories<Payments>().AddAsync(payment);

                    int rowsAffected = await _unitofWork.SaveChangesAsync();
                    if (rowsAffected > 0)
                    {
                        responseModel.Data = createPaymentsDTO;
                        responseModel.StatusCode = 200;
                    }
                }
                else
                {
                    responseModel.StatusCode = 400; // Not enough money in the account
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
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Payments>().GetByIdAsync(id);
                if(data != null)
                {
                    _unitofWork.GetRepositories<Payments>().Delete(data);
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

        public async Task<ResponseModel<List<GetPaymentsDTO>>> GetAll()
        {
            ResponseModel<List<GetPaymentsDTO>> responseModel = new ResponseModel<List<GetPaymentsDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Payments>().GetAll().ToListAsync();
                if(data != null)
                {
                    var payments = _mapper.Map<List<GetPaymentsDTO>>(data);
                    responseModel.Data = payments;
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

        public async Task<ResponseModel<GetPaymentsDTO>> GetPaymentsById(int id)
        {
            ResponseModel<GetPaymentsDTO> responseModel = new ResponseModel<GetPaymentsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Payments>().GetByIdAsync(id);
                if(data != null)
                {
                    var feature = _mapper.Map<GetPaymentsDTO>(data);
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

        public async Task<ResponseModel<GetPaymentsDTO>> MaximumPayment()
        {
            ResponseModel<GetPaymentsDTO> responseModel = new ResponseModel<GetPaymentsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var maxpayment = await _unitofWork.GetRepositories<Payments>().GetAll().MaxAsync(x => x.PaymentAmount);
                var payment = await _unitofWork.GetRepositories<Payments>().GetAll().FirstOrDefaultAsync(x =>
                x.PaymentAmount == maxpayment);
                if(payment != null)
                {
                    var paymentdto = _mapper.Map<GetPaymentsDTO>(payment);
                    responseModel.Data = paymentdto;
                    responseModel.StatusCode = 200;
                }
                else
                {
                    responseModel.StatusCode = 404;
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> UpdatePayments(UpdatePaymentsDTO updatePaymentsDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<Payments>().GetByIdAsync(id);
                if (data != null)
                {
                    _mapper.Map(updatePaymentsDTO, data);
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
