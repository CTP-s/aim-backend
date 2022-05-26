using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aim_backend.Controllers
{
    [Route("api/enrollement")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost]
        public async Task<IActionResult> PostEnrollment(EnrollDto enrollDto)
        {
            var enrollment = await _enrollmentService.PostEnrollment(enrollDto);

            if (enrollment == null) return BadRequest("Invalid enrollment.");

            return Ok(enrollment);
        }

    }
}