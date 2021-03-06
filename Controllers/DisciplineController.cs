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

        [HttpGet("regular/curriculum/{id}")]
        public async Task<IActionResult> GetRegularDisciplinesByCurriculum(int id)
        {
            var regularDisciplines = await _disciplineService.GetRegularDisciplinesByCurriculum(id);

            if (regularDisciplines == null) return NotFound("No disciplines for current curriculum.");

            return Ok(regularDisciplines);
        }

        [HttpGet("optional/student/{id}")]
        public async Task<IActionResult> GetOptionalDisciplineByStudent(int id)
        {
            var optionalCourse = await _disciplineService.GetOptionalCourseByStudent(id);

            if (optionalCourse == null) return NotFound("No optional course found for the given student.");

            return Ok(optionalCourse);
        }

        [HttpGet("regular/student/{id}")]
        public async Task<IActionResult> GetRegularDisciplinesByStudentId(int id)
        {
            var regularDisciplines = await _disciplineService.GetRegularDisciplinesByStudentId(id);

            if (regularDisciplines == null) return NotFound("No disciplines for current student.");

            return Ok(regularDisciplines);
        }

        [HttpGet("lecturer/{id}")]
        public async Task<IActionResult> GetDisciplinesByLecturerId(int id)
        {
            var disciplines = await _disciplineService.GetDisciplinesByLecturer(id);

            if (disciplines == null) return NotFound("No disciplines for current lecturer.");

            return Ok(disciplines);
        }

        [HttpPut("optional/max")]
        public async Task<IActionResult> SetMaximumNumberOfStudents(DisciplineUpdateDTO disciplineUpdateDTO)
        {
            var uptadedDiscipline = await _disciplineService.SetMaxStudentsOptionalCourse(disciplineUpdateDTO);

            if (uptadedDiscipline == null) return BadRequest("Discipline with given id does not exist.");

            return Ok(uptadedDiscipline);
        }
    }
}