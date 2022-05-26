using System.Threading.Tasks;

namespace aim_backend.Services
{
    public interface ICurriculumService
    {
        Task<int> GetCurriculumIdByStudent(int studentId);
    }
}