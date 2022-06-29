using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTO;
using Core.Exceptions;
using Core.Helpers;
using Core.Interfaces.CustomServices;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly IOptions<JwtOptions> _jwtOptions;
        protected readonly IJwtService _jwtService;

        public AccountService(UserManager<ApplicationUser> userManager, IOptions<JwtOptions> jwtOptions, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
            _jwtService = jwtService;
        }

        public async Task RegisterAsync(RegisterUserDto data)
        {
            var user = new ApplicationUser()
            {
                UserName = data.Email,
                Email = data.Email,
                FirstName = data.FirstName,
                LastName = data.LastName
            };
            var result = await _userManager.CreateAsync(user, data.Password);

            if (!result.Succeeded)
            {
                StringBuilder messageBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    messageBuilder.AppendLine(error.Description);
                }

                throw new HttpException(messageBuilder.ToString(), System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}
