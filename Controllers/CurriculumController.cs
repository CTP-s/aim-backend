using System.Threading.Tasks;
using aim_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace aim_backend.Controllers
{
    [Route("api/curriculum")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly ICurriculumService _curriculumService;
        public CurriculumController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetCurriculumIdByStudent(int id)
        {
            var curriculumId = await _curriculumService.GetCurriculumIdByStudent(id);

            if (curriculumId < 0) return NotFound("No curriculum for the current student.");

            return Ok(curriculumId);
        }
    }
}