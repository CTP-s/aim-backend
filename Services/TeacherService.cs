using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.DTOs;
using aim_backend.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeacherService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IList<LecturerDTO>> GetAllLecturers()
        {
            var _lecturersJoin = await _context.Teachers.Join(
                _context.Courses,
                teacher => teacher.Id,
                course => course.TeacherId,
                (teacher, course) => new
                {
                    TeacherId = teacher.Id,
                    FirsnName = teacher.FirstName,
                    Lastname = teacher.LastName,
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    CourseSemester = course.Semester
                }
            ).ToListAsync();

            var _lecturers = new List<LecturerDTO>();

            _lecturersJoin.ForEach(lecturer =>
            {
                _lecturers.Add(new LecturerDTO
                {
                    LecturerId = lecturer.TeacherId,
                    Firstname = lecturer.FirsnName,
                    Lastname = lecturer.Lastname,
                    CourseId = lecturer.CourseId,
                    CourseName = lecturer.CourseName,
                    CourseSemester = lecturer.CourseSemester
                });
            });

            if (_lecturers.Count == 0) return null;

            return _lecturers;
        }
    }
}