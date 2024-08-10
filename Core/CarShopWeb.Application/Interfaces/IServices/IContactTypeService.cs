using CarShopWeb.Application.DTOs.ContactTypeDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface IContactTypeService
    {
        Task<ResponseModel<List<GetContactTypeDTO>>> GetAll();
        Task<ResponseModel<CreateContactTypeDTO>> CreateContact(CreateContactTypeDTO createContactTypeDTO);
        Task<ResponseModel<bool>> UpdateContact(CreateContactTypeDTO updateContactDTO,int id);
        Task<ResponseModel<bool>> DeleteContact(int id);
        Task<ResponseModel<GetContactTypeDTO>> GetContactById(int id);
    }
}
