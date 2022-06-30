using Core.Interfaces.CustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Core.Helpers;

namespace Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly UserManager<ApplicationUser> _userManager;
        public JwtService(IOptions<JwtOptions> jwtOptions, UserManager<ApplicationUser> userManager)
        {
            this._jwtOptions = jwtOptions;
            _userManager = userManager;
        }
        public string CreateToken(ApplicationUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            List<Claim> claims = new List<Claim>()
            {
                new Claim("name", user.UserName)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.Value.LifeTime),
                issuer: _jwtOptions.Value.Issuer,
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public IEnumerable<Claim> SetClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.UserName),
            };

            return claims;
        }
    }
}
