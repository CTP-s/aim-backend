using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.Models;

namespace aim_backend.Services
{
    public interface IFacultyService
    {
        Task<IList<Faculty>> GetFaculties();

        Task<IList<Department>> GetDepartments(int facultyId);

        Task<IList<StudyLine>> GetStudyLines(int departmentId);

        Task<IList<YearOfStudy>> GetYearOfStudies(int studyLineId);
    }
}