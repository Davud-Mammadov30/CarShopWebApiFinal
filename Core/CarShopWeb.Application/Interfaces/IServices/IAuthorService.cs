using CarShopWeb.Application.DTOs.TokenDTO;
using CarShopWeb.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface IAuthorService
    {
        Task<ResponseModel<TokenDTO>> LoginAsync(string userNameOrEmail, string password);
        Task<ResponseModel<TokenDTO>> LoginWithRefreshTokenAsync(string refreshToken);
        Task<ResponseModel<bool>> LogOut(string userNameorEmail);
        public Task<ResponseModel<bool>> PasswordResetAsync(string userNameorEmail,string currentpas,string newpas);
    }
}
