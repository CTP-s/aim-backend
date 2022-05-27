using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aim_backend.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ICurriculumService _curriculumService;

        public StudentController(IStudentService studentService, ICurriculumService curriculumService)
        {
            _studentService = studentService;
            _curriculumService = curriculumService;
        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetStudentInfo(int id)
        {
            var studentInfo = await _studentService.GetStudentInfo(id);

            if (studentInfo == null) return NotFound("Could not retrieve user info.");

            return Ok(studentInfo);
        }

        [HttpGet("grades/{id}")]
        public async Task<IActionResult> GetStudentGrades(int id)
        {
            var studentGrades = await _studentService.GetStudentGrades(id);

            if (studentGrades == null)
            {
                return NotFound("No grades for given student");
            }

            return Ok(studentGrades);
        }

        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetStudentsByCourse(int id)
        {
            var students = await _studentService.GetStudentsByCourse(id);

            if (students == null) return NotFound("No students for the current course.");

            return Ok(students);
        }

    }
}