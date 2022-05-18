using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aim_backend.Controllers
{
    [Route("api/studentinfo")]
    [ApiController]
    public class StudentController: ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("StudentGrades")]
        public async Task<IActionResult> GetStudentGrades(GetGradesDto getGradesDto)
        {
            var studentGrades = await _studentService.GetStudentGrades(getGradesDto);

            if (studentGrades == null) 
            {
                return NotFound("No grades for given student");
            }

            return Ok(studentGrades);
        }

    }
}