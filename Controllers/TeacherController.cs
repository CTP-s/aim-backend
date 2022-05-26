using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aim_backend.Controllers
{
    [ApiController]
    [Route("/api/teacher")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("lecturer")]
        public async Task<IActionResult> GetAllLecturers()
        {
            var lecturers = await _teacherService.GetAllLecturers();

            if (lecturers == null) return NotFound("No lecturers available.");

            return Ok(lecturers);
        }

        [HttpPost("grades")]
        public async Task<IActionResult> PostGrade(GradeDto gradeDto)
        {
            var grade = await _teacherService.PostGrade(gradeDto);

            return Ok(grade);
        }
    }
}