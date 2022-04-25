using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace aim_backend.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginController(ILoginService loginService, IMapper mapper, IConfiguration configuration)
        {
            _loginService = loginService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginDto userLogin)
        {
            var user = await _loginService.VerifyUserCredentials(userLogin);

            if (user == null) return Unauthorized("Invalid credentials.");

            var userLoginResponse = _loginService.Login(user);

            return Ok(userLoginResponse);
        }

    }
}