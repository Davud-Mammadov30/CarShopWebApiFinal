using AutoMapper;
using CarShopWeb.Application.DTOs.AccountDetailDTOs;
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
    public class AccountDetailsService : IAccountDetailService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public AccountDetailsService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel<CreateAccountDetailDTO>> CreateAccount(CreateAccountDetailDTO accountDetailDTO)
        {
            ResponseModel<CreateAccountDetailDTO> responseModel = new ResponseModel<CreateAccountDetailDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if (accountDetailDTO != null)
                {
                    var data = _mapper.Map<AccountDetail>(accountDetailDTO);
                    await _unitofWork.GetRepositories<AccountDetail>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if (rowsaffected > 0)
                    {
                        responseModel.Data = accountDetailDTO;
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

        public async Task<ResponseModel<bool>> DeleteAccount(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<AccountDetail>().GetByIdAsync(id);
                if (data != null)
                {
                    _unitofWork.GetRepositories<AccountDetail>().Delete(data);
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

        public async Task<ResponseModel<GetAccountDetailsDTO>> GetAccountById(int id)
        {
            ResponseModel<GetAccountDetailsDTO> responseModel = new ResponseModel<GetAccountDetailsDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<AccountDetail>().GetByIdAsync(id);
                if (data != null)
                {
                    var accountdetailsDto = _mapper.Map<GetAccountDetailsDTO>(data);
                    responseModel.Data = accountdetailsDto;
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

        public async Task<ResponseModel<List<GetAccountDetailsDTO>>> GetAll()
        {
            ResponseModel<List<GetAccountDetailsDTO>> responseModel = new ResponseModel<List<GetAccountDetailsDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<AccountDetail>().GetAll().ToListAsync();
                var accounts = _mapper.Map<List<GetAccountDetailsDTO>>(data);
                responseModel.Data = accounts;
                responseModel.StatusCode = 200;
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> UpdateAccount(UpdateAccountDetailDTO accountDetailDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<AccountDetail>().GetByIdAsync(id);
                if (data != null)
                {
                    var account = _mapper.Map(accountDetailDTO, data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if (rowsaffected > 0)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
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
