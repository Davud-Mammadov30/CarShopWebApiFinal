using CarShopWeb.Application.DTOs.TokenDTO;
using CarShopWeb.Application.Interfaces.IServices;
using CarShopWeb.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Infrastructure.Implementations
{
    public class TokenHandler : ITokenHandler
    {
        readonly IConfiguration _configuration;
        readonly UserManager<AppUser> _userManager;

        public TokenHandler(IConfiguration configuration, UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<TokenDTO> CreateAccessToken(AppUser user)
        {
            TokenDTO tokenDTO = new TokenDTO();
            SymmetricSecurityKey SecurityKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
            SigningCredentials signingCredentials = new(SecurityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            tokenDTO.ExpirationTime = DateTime.UtcNow.AddMinutes(5);
            JwtSecurityToken securityToken = new(
                audience: _configuration["JWT:Audience"],
                issuer: _configuration["JWT:Issure"],
                expires: tokenDTO.ExpirationTime, //life time
                notBefore: DateTime.UtcNow, //islemeye baslayacagi vaxt
                signingCredentials: signingCredentials,
                claims: claims
                );

            JwtSecurityTokenHandler tokenHandler = new();
            //todo burda creat mehodun isledib sonra bunu isletmisik jwtAutoAndLogger dersimizde
            tokenDTO.AccessToken = tokenHandler.WriteToken(securityToken);

            //refresh token yaradib veririk
            tokenDTO.RefreshToken = CreateRefreshToken();

            return tokenDTO;
        }

        public string CreateRefreshToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:RefreshTokenSecret"]); // Refresh token için gizli sifre
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var refreshToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(refreshToken);
        }

    }
}
