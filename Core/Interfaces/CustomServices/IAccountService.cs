using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.DTO.Identity;
using Entities;

namespace Core.Interfaces.CustomServices
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterUserDto data);
        Task<AuthorizationDto> LoginAsync(string email, string password);
        //Task<AuthorizationDTO> RefreshTokenAsync(AuthorizationDTO userTokensDTO);
        Task LogoutAsync(UserLogoutDto userTokensDTO);
        Task<AuthorizationDto> GenerateToken(ApplicationUser user);
        Task<ApplicationUser> AuthenticateGoogleUserAsync(GoogleUserRequest request);
        //Task SentResetPasswordTokenAsync(string userEmail);
    }
}
