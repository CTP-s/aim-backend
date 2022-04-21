using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Models;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aim_backend.Controllers
{
    [Route("api/Register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _registerService.GetUserById(id);

            if (user == null) return NotFound("User with given id not found.");

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserCredentialsDto userCredentials)
        {
            var postUser = await _registerService.PostUser(userCredentials);

            if (postUser == null) return BadRequest("User with given email already exists.");

            return Created(nameof(GetUserById), postUser);
        }

    }
}