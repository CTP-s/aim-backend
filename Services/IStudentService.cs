using System.Threading.Tasks;
using aim_backend.DTOs;

namespace aim_backend.Services
{
    public interface IStudentService
    {
         Task<GradesDto> GetStudentGrades(GetGradesDto getGradesDto);
    }
    
}