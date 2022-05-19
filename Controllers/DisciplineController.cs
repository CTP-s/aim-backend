using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace aim_backend.Controllers
{
    [Route("api/discipline")]
    [ApiController]
    public class DisciplineController : ControllerBase
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
        public async Task<IActionResult> GetDisciplines()
        {
            var disciplines = await _disciplineService.GetDisciplines();

            if (disciplines == null) return NotFound("No disciplines found.");

            return Ok(disciplines);
        }

        [HttpPut]
        public async Task<IActionResult> SetMaximumNumberOfStudents(DisciplineUpdateDTO disciplineUpdateDTO)
        {
            var uptadedDiscipline = await _disciplineService.SetMaxStudentsOptionalCourse(disciplineUpdateDTO);

            if (uptadedDiscipline == null) return BadRequest("Discipline with given id does not exist.");

            return Ok(uptadedDiscipline);
        }
    }
}