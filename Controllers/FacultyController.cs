using System.Threading.Tasks;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aim_backend.Controllers
{
    [ApiController]
    [Route("api/faculty")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;
        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFaculties()
        {
            var faculties = await _facultyService.GetFaculties();

            if (faculties == null) return NotFound("No faculties available.");

            return Ok(faculties);
        }

        [HttpGet("department/{facultyId}")]
        public async Task<IActionResult> GetDepartments(int facultyId)
        {
            var departments = await _facultyService.GetDepartments(facultyId);

            if (departments == null) return NotFound("No departments available.");

            return Ok(departments);
        }

        [HttpGet("studyline/{departmentId}")]
        public async Task<IActionResult> GetStudyLines(int departmentId)
        {
            var studyLines = await _facultyService.GetStudyLines(departmentId);

            if (studyLines == null) return NotFound("No study lines available.");

            return Ok(studyLines);
        }


        [HttpGet("yearofstudy/{studyLineId}")]
        public async Task<IActionResult> GetYearOfStudies(int studyLineId)
        {
            var yearOfStudies = await _facultyService.GetYearOfStudies(studyLineId);

            if (yearOfStudies == null) return NotFound("No years of study available.");

            return Ok(yearOfStudies);
        }

    }
}