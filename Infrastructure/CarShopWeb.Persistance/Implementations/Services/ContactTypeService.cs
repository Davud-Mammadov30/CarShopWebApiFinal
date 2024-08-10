using AutoMapper;
using CarShopWeb.Application.DTOs.ContactTypeDTOs;
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
    public class ContactTypeService : IContactTypeService
    {
        private readonly IUnitofwork _unitofWork;
        private readonly IMapper _mapper;
        public ContactTypeService(IUnitofwork unitofWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<ResponseModel<CreateContactTypeDTO>> CreateContact(CreateContactTypeDTO createContactTypeDTO)
        {
            ResponseModel<CreateContactTypeDTO> responseModel = new ResponseModel<CreateContactTypeDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                if(createContactTypeDTO != null)
                {
                    var data = _mapper.Map<ContactType>(createContactTypeDTO);
                    await _unitofWork.GetRepositories<ContactType>().AddAsync(data);
                    int rowsaffected = await _unitofWork.SaveChangesAsync();
                    if(rowsaffected > 0)
                    {
                        responseModel.Data = createContactTypeDTO;
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

        public async Task<ResponseModel<bool>> DeleteContact(int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<ContactType>().GetByIdAsync(id);
                if(data != null)
                {
                    _unitofWork.GetRepositories<ContactType>().Delete(data);
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

        public async Task<ResponseModel<List<GetContactTypeDTO>>> GetAll()
        {
            ResponseModel<List<GetContactTypeDTO>> responseModel = new ResponseModel<List<GetContactTypeDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<ContactType>().GetAll().ToListAsync();
                if (data != null)
                {
                    var contacts = _mapper.Map<List<GetContactTypeDTO>>(data);
                    responseModel.Data = contacts;
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

        public async Task<ResponseModel<GetContactTypeDTO>> GetContactById(int id)
        {
            ResponseModel<GetContactTypeDTO> responseModel = new ResponseModel<GetContactTypeDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<ContactType>().GetByIdAsync(id);
                if(data != null)
                {
                    var contact = _mapper.Map<GetContactTypeDTO>(data);
                    responseModel.Data = contact;
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

        public async Task<ResponseModel<bool>> UpdateContact(CreateContactTypeDTO updateContactDTO, int id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                var data = await _unitofWork.GetRepositories<ContactType>().GetByIdAsync(id);
                if(data != null)
                {
                    _mapper.Map(updateContactDTO,data);
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
