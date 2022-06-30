using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.DTO.Identity;
using Core.Helpers;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace MessengerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration, IUserService userService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _env = env;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDto data)
        {
            var tokens = await _accountService.LoginAsync(data.Email, data.Password);
            return Ok(tokens);
        }
        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync([FromBody] UserLogoutDto userLogoutDTO)
        {
            await _accountService.LogoutAsync(userLogoutDTO);
            return Ok();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            try
            {
                if (registerDto.Photo != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                                            ".jpeg";
                    string pathSaveImages = InitStaticFiles
                        .CreateImageByFileName(_env, _configuration,
                            new string[] { "Folder" },
                            randomFilename, registerDto.Photo, false, false);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            await _accountService.RegisterAsync(registerDto);
            
            return Ok("Successfully Registration");
        }
    }
}
