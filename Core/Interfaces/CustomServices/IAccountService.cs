using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;

namespace Core.Interfaces.CustomServices
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterUserDto data);
        //Task<AuthorizationDTO> LoginAsync(string email, string password);
        //Task<AuthorizationDTO> RefreshTokenAsync(AuthorizationDTO userTokensDTO);
        //Task LogoutAsync(AuthorizationDTO userTokensDTO);
        //Task SentResetPasswordTokenAsync(string userEmail);
    }
}
