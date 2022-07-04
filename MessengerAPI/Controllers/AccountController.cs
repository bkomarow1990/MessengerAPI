using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTO;
using Core.DTO.Identity;
using Core.Helpers;
using Core.Interfaces.CustomServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IRecaptchaService _recaptchaService;

        public AccountController(IAccountService accountService, IMapper mapper, IWebHostEnvironment env, IConfiguration configuration, IUserService userService, IRecaptchaService recaptchaService)
        {
            _accountService = accountService;
            _mapper = mapper;
            _env = env;
            _configuration = configuration;
            _userService = userService;
            _recaptchaService = recaptchaService;
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
            if (!_recaptchaService.IsValid(registerDto.RecaptchaToken))
            {
                return BadRequest(new { error = "Recaptcha not valid" });
            }
            try
            {
                if (registerDto.Image != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                                            ".jpeg";
                    string pathSaveImages = InitStaticFiles
                        .CreateImageByFileName(_env, _configuration,
                            new string[] { "Folder" },
                            randomFilename, registerDto.Image, false, false);
                    registerDto.Image = randomFilename;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            await _accountService.RegisterAsync(registerDto);
            
            return Ok(new RegisterResponseDto{ Token = "22" });
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> GoogleAuthenticate([FromBody] GoogleUserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(it => it.Errors).Select(it => it.ErrorMessage));
            var user = await _accountService.AuthenticateGoogleUserAsync(request);
            return Ok(await _accountService.GenerateToken(user));
        }
        //public async Task GoogleLogin()
        //{
        //    await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
        //    {
        //        RedirectUri = Url.Action("GoogleResponse")
        //    });
        //}
        //[HttpPost]
        //public async Task<IActionResult> GoogleResponse()
        //{
        //    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
        //    {
        //        claim.Issuer,
        //        claim.OriginalIssuer,
        //        claim.Type,
        //        claim.Value
        //    });
        //    return claims;
        //}
        //[HttpPost]
        //public Task<IActionResult> GoogleLogin()
        //{

        //}
    }
}
