using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public FacultyService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IList<Department>> GetDepartments(int facultyId)
        {
            var departments = await _context.Departments.Where(department => department.FacultyId == facultyId).ToListAsync();

            if (departments.Count == 0) return null;

            return departments;
        }

        public async Task<IList<Faculty>> GetFaculties()
        {
            var faculties = await _context.Faculties.ToListAsync();

            if (faculties.Count == 0) return null;

            return faculties;
        }

        public async Task<IList<StudyLine>> GetStudyLines(int departmentId)
        {
            var studyLines = await _context.StudyLines.Where(studyLine => studyLine.DepartmentId == departmentId).ToListAsync();

            if (studyLines.Count == 0) return null;

            return studyLines;
        }

        public async Task<IList<YearOfStudy>> GetYearOfStudies(int studyLineId)
        {
            var yearOfStudies = await _context.YearOfStudies.Where(yearOfStudy => yearOfStudy.StudyLineId == studyLineId).ToListAsync();

            if (yearOfStudies.Count == 0) return null;

            return yearOfStudies;
        }
    }
}