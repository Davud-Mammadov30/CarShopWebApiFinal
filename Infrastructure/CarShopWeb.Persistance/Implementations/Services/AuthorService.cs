using CarShopWeb.Application.DTOs.TokenDTO;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Application.Models;
using CarShopWeb.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Persistence.Implementations.Services
{
    public class AuthorService : IAuthorService
    {
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            ITokenHandler tokenHandler, IUserService userService, IHttpContextAccessor httpContextAccessor = null)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }
        public async Task<ResponseModel<TokenDTO>> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime, int refreshTokenMoreLife)
        {
            ResponseModel<TokenDTO> responseModel = new ResponseModel<TokenDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                AppUser user = await _userManager.FindByNameAsync(userNameOrEmail);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(userNameOrEmail);
                }
                else
                {
                    responseModel.StatusCode = 500;
                }
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (result.Succeeded)
                {
                    TokenDTO tokenDTO = await _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                    await _userService.UpdateRefreshToken(tokenDTO.RefreshToken, user, tokenDTO.ExpirationTime, accessTokenLifeTime);
                    responseModel.Data = tokenDTO;
                    responseModel.StatusCode = 200;
                }
                else
                {
                    responseModel.StatusCode = 401;
                }
            }
            catch 
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<TokenDTO>> LoginWithRefreshTokenAsync(string refreshToken, int accessTokenLifeTime, int refreshTokenMoreLife)
        {
            ResponseModel<TokenDTO> responseModel = new ResponseModel<TokenDTO>()
            {
                Data = null,
                StatusCode = 400
            };
            try
            {
                AppUser? user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
                if (user != null && user?.RefreshTokenEndTime> DateTime.UtcNow)
                {
                    TokenDTO tokenDTO = await _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                    await _userService.UpdateRefreshToken(tokenDTO.RefreshToken,user, tokenDTO.ExpirationTime, refreshTokenMoreLife);
                    responseModel.Data = tokenDTO;
                    responseModel.StatusCode = 200;
                }
                else
                {
                    responseModel.StatusCode = 401;
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> LogOut(string userNameorEmail)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                AppUser user = await _userManager.FindByNameAsync(userNameorEmail);
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(userNameorEmail);
                }
                else
                {
                    responseModel.StatusCode = 500;
                }
                var result = await _userManager.UpdateAsync(user);
                await _signInManager.SignOutAsync();
                if(result.Succeeded)
                {
                    responseModel.Data = true;
                    responseModel.StatusCode = 200;
                }
                else
                {
                    responseModel.StatusCode = 401;
                }
            }
            catch
            {
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> PasswordResetAsync(string userNameorEmail, string currentpas, string newpas)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>
            {
                Data = false,
                StatusCode = 400
            };
            try
            {
                AppUser user = await _userManager.FindByEmailAsync(userNameorEmail);
                if(user == null)
                {
                    user = await _userManager.FindByNameAsync(userNameorEmail);
                }
                else
                {
                    var data = await _userManager.ChangePasswordAsync(user, currentpas, newpas);
                    if(data.Succeeded)
                    {
                        responseModel.Data = true;
                        responseModel.StatusCode = 200;
                    }
                    else
                    {
                        responseModel.StatusCode = 401;
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
