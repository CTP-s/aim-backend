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

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetTeacherInfo(int id)
        {
            var teacher = await _teacherService.GetTeacherInfo(id);

            if (teacher == null) return NotFound("Teacher not found.");

            return Ok(teacher);
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

        [HttpPost("propose-optional")]
        public async Task<IActionResult> ProposeOptionalCourse(OptionalCourseProposedDto optionalCourseProposedDto)
        {
            var optionalCourse = await _teacherService.ProposeOptional(optionalCourseProposedDto);

            if (optionalCourse == null) return BadRequest("Could not process course proposal.");

            return Ok(optionalCourse);
        }

        [HttpPost("approve-optional")]
        public async Task<IActionResult> ApproveOptionalCourse(OptionalCourseApproveDto optionalCourseApproveDto)
        {
            var optionalCourse = await _teacherService.ApproveOptional(optionalCourseApproveDto);

            if (optionalCourse == null) return BadRequest("Could not process course approval.");

            return Ok(optionalCourse);
        }
    }
}