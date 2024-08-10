﻿using AutoMapper;
using CarShopWeb.Application.DTOs.UsersDTOs;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Application.Models;
using CarShopWeb.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Infrastructure.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ResponseModel<bool>> AssignRoletoUserAsync(string userId, string[] roles)
        {
            AppUser appUser = await _userManager.FindByIdAsync(userId);
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400,
            };
            if (appUser != null)
            {
                var userRole = await _userManager.GetRolesAsync(appUser);
                await _userManager.RemoveFromRolesAsync(appUser, userRole);
                IdentityResult result = await _userManager.AddToRolesAsync(appUser, roles);
                if (result.Succeeded)
                {
                    responseModel.Data = true;
                    responseModel.StatusCode = 200;
                }
            }
            return responseModel;
        }

        public async Task<ResponseModel<CreateUserResponseDTO>> CreateAsync(CreateUserDTO model)
        {
            ResponseModel<CreateUserResponseDTO> responseModel = new ResponseModel<CreateUserResponseDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            CreateUserResponseDTO responseDTO = new CreateUserResponseDTO()
            {
                Message = "User not created",
                Succeeded = false
            };
            if (model != null)
            {
                var user = _mapper.Map<AppUser>(model);
                user.Id = Guid.NewGuid().ToString();
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    responseDTO.Message = string.Join("\n", result.Errors.Select(error => $"{error.Code}-{error.Description}"));
                }
                responseDTO.Message = "User created successfully";
                responseDTO.Succeeded = true;

                responseModel.Data = responseDTO;
                responseModel.StatusCode = 200;
            }
            AppUser appUser = await _userManager.FindByNameAsync(model.UserName);
            if (appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(model.Email);
                if (appUser == null)
                {
                    appUser = await _userManager.FindByIdAsync(appUser.Id);
                }
            }
            if (appUser != null)
                await _userManager.AddToRoleAsync(appUser, "User");

            return responseModel;
        }

        public async Task<ResponseModel<bool>> DeleteUserAsync(string userIOorName)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            AppUser appUser = await _userManager.FindByIdAsync(userIOorName);
            if (appUser == null)
            {
                appUser = await _userManager.FindByNameAsync(userIOorName);
            }
            if(appUser == null)
            {
                responseModel.StatusCode = 404;
            }
            IdentityResult result = await _userManager.DeleteAsync(appUser);
            if (result.Succeeded)
            {
                responseModel.Data = true;
                responseModel.StatusCode = 200;
            }
            return responseModel;
        }

        public async Task<ResponseModel<List<UserGetDTO>>> GetAllUsersAsync()
        {
            ResponseModel<List<UserGetDTO>> responseModel = new ResponseModel<List<UserGetDTO>>()
            {
                Data = null,
                StatusCode = 400
            };
            List<AppUser> users = _userManager.Users.ToList();
            if(users.Count > 0 && users != null)
            {
                List<UserGetDTO> userGetDTOs = _mapper.Map<List<UserGetDTO>>(users);
                responseModel.Data = userGetDTOs;
                responseModel.StatusCode=200;
            }
            return responseModel;
        }

        public async Task<ResponseModel<string[]>> GetRolesToUserAsync(string userIdOrName)
        {
            ResponseModel<string[]> responseModel = new ResponseModel<string[]>()
            {
                Data = null,
                StatusCode = 400
            };
            var user = await _userManager.FindByIdAsync(userIdOrName);
            if (user == null) 
            {
                user = await _userManager.FindByNameAsync(userIdOrName);
            }
            if(user != null)
            {
                var getRoles = await _userManager.GetRolesAsync(user);
                responseModel.Data = getRoles.ToArray();
                responseModel.StatusCode=200;
            }
            return responseModel;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate)
        {
            if(user != null)
            {
                user.RefreshToken = refreshToken;
                user.ExpiredDate = accessTokenDate;
                await _userManager.UpdateAsync(user);
            }
        }

        public async Task<ResponseModel<bool>> UpdateUserAsync(UserUpdateDTO model)
        {
            var responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            if(model != null)
            {
                var user = await _userManager.FindByIdAsync(model.UserID);
                if (user == null)
                {
                    responseModel.StatusCode = 404;
                }
                else
                {
                    user =  _mapper.Map<AppUser>(model);
                    var result = await _userManager.UpdateAsync(user);
                    if(result.Succeeded) 
                    {
                        responseModel.Data=true;
                        responseModel.StatusCode = 200;
                    }
                }
            }
            return responseModel;
        }
    }
}
