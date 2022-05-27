using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Models;

namespace aim_backend.Services
{
    public interface ITeacherService
    {
        Task<TeacherInfoDto> GetTeacherInfo(int id);

        Task<IList<LecturerDTO>> GetAllLecturers();

        Task<Grade> PostGrade(GradeDto gradeDto);

        Task<OptionalCourse> ProposeOptional(OptionalCourseProposedDto optionalCourseProposedDto);

        Task<OptionalCourse> ApproveOptional(OptionalCourseApproveDto optionalCourseApproveDto);
    }
}