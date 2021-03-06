using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.DTOs;

namespace aim_backend.Services
{
    public interface IStudentService
    {
        Task<StudentInfoDto> GetStudentInfo(int id);

        Task<IList<GradesDto>> GetStudentGrades(int id);

        Task<IList<StudentDto>> GetStudentsByCourse(int courseId);
    }

}