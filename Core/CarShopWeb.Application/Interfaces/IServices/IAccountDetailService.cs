using CarShopWeb.Application.DTOs.AccountDetailDTOs;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface IAccountDetailService
    {
        Task<ResponseModel<List<GetAccountDetailsDTO>>> GetAll();
        Task<ResponseModel<CreateAccountDetailDTO>> CreateAccount(CreateAccountDetailDTO accountDetailDTO);
        Task<ResponseModel<bool>> UpdateAccount(UpdateAccountDetailDTO accountDetailDTO,int id);
        Task<ResponseModel<bool>> DeleteAccount(int id);
        Task<ResponseModel<GetAccountDetailsDTO>> GetAccountById(int id);
    }
}
