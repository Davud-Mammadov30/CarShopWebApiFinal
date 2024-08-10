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
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<ResponseModel<bool>> CreateRole(string name)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            IdentityResult result = await _roleManager.CreateAsync(new() {Id = Guid.NewGuid().ToString(), Name = name});
            if(result.Succeeded)
            {
                responseModel.Data = true;
                responseModel.StatusCode = 200;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> DeleteRole(string id)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            var role = await _roleManager.FindByIdAsync(id);
            if(role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if(result.Succeeded)
                {
                    responseModel.Data = true;
                    responseModel.StatusCode = 200;
                }
            }
            return responseModel;
        }

        public async Task<ResponseModel<object>> GetAllroles()
        {
            ResponseModel<object> responseModel = new ResponseModel<object>()
            {
                Data = true,
                StatusCode = 400
            };
            var roles = await _roleManager.Roles.ToListAsync();
            if(roles.Count > 0)
            {
                responseModel.Data = roles;
                responseModel.StatusCode = 200;
            }
            return responseModel;
        }

        public async Task<ResponseModel<object>> GetRoleById(string id)
        {
            ResponseModel<object> responseModel = new ResponseModel<object>()
            {
                Data = null,
                StatusCode = 400
            };
            var roles = await _roleManager.FindByIdAsync(id);
            if(roles != null)
            {
                responseModel.Data = roles;
                responseModel.StatusCode = 200;
            }
            return responseModel;
        }

        public async Task<ResponseModel<bool>> UpdateRole(string id, string name)
        {
            ResponseModel<bool> responseModel = new ResponseModel<bool>()
            {
                Data = false,
                StatusCode = 400
            };
            var role = await _roleManager.FindByIdAsync(id);
            if(role != null)
            {
                role.Name = name;
                IdentityResult result = await _roleManager.UpdateAsync(role);
                if(result.Succeeded)
                {
                    responseModel.Data = true;
                    responseModel.StatusCode = 200;
                }
            }
            return responseModel;
        }
    }
}
