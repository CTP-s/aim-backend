using System.Threading.Tasks;
using aim_backend.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace aim_backend.Controllers
{
    [Route("api/discipline")]
    [ApiController]
    public class DisciplineController: ControllerBase
    {
        private readonly IDisciplineService _disciplineService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public DisciplineController(IDisciplineService disciplineService, IMapper mapper, IConfiguration configuration)
        {
            _disciplineService = disciplineService;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetDisciplines() {
            var disciplines = await _disciplineService.GetDisciplines();

            if (disciplines == null) return NotFound("No disciplines found.");

            return Ok(disciplines);
        }
    }
}