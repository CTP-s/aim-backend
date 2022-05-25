using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.DTOs;

namespace aim_backend.Services
{
    public interface IStudentService
    {
        Task<IList<GradesDto>> GetStudentGrades(int id);
    }

}