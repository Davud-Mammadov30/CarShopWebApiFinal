using CarShopWeb.Application.DTOs.TokenDTO;
using CarShopWeb.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Interfaces.IServices
{
    public interface ITokenHandler
    {
        Task<TokenDTO> CreateToken(AppUser user);
        string CreateRefreshToken();
    }
}
