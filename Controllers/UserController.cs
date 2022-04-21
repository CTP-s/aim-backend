using System.Threading.Tasks;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace aim_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var user = await _userService.GetUser(id);

            if (user == null) 
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var userList = await _userService.GetUserList();

            if (userList == null)
            {
                return NotFound();
            }

            return Ok(userList);
        }
    }
}