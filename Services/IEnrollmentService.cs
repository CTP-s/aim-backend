using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Models;

namespace aim_backend.Services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> PostEnrollment(EnrollDto enrollment);
    }
}