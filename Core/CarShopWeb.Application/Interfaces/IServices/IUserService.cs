using CarShopWeb.Application.DTOs.UsersDTOs;
using CarShopWeb.Application.Models;
using CarShopWeb.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface IUserService
    {
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate);
        public Task<ResponseModel<bool>> AssignRoletoUserAsync(string userId, string[] roles);
        Task<ResponseModel<CreateUserResponseDTO>> CreateAsync(CreateUserDTO model);
        public Task<ResponseModel<List<UserGetDTO>>> GetAllUsersAsync();
        public Task<ResponseModel<string[]>> GetRolesToUserAsync(string userIdOrName);
        public Task<ResponseModel<bool>> DeleteUserAsync(string userIOorName);
        public Task<ResponseModel<bool>> UpdateUserAsync(UserUpdateDTO model);
    }
}
