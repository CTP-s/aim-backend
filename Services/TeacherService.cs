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
        public async Task<TeacherInfoDto> GetTeacherInfo(int id)
        {
            var teacher = await _context.Teachers.Where(teacher => teacher.Id == id).FirstOrDefaultAsync();

            if (teacher == null) return null;

            var teacherInfoDto = _mapper.Map<TeacherInfoDto>(teacher);

            return teacherInfoDto;
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

        public async Task<Grade> PostGrade(GradeDto gradeDto)
        {
            var grade = _mapper.Map<Grade>(gradeDto);

            _context.Grades.Add(grade);

            await _context.SaveChangesAsync();

            return grade;
        }

        public async Task<OptionalCourse> ProposeOptional(OptionalCourseProposedDto optionalCourseProposedDto)
        {
            var optionalCourse = _mapper.Map<OptionalCourse>(optionalCourseProposedDto);
            optionalCourse.Approved = 0;

            _context.OptionalCourses.Add(optionalCourse);

            await _context.SaveChangesAsync();

            return optionalCourse;
        }

        public async Task<OptionalCourse> ApproveOptional(OptionalCourseApproveDto optionalCourseApproveDto)
        {
            var optionalCourse = await _context.OptionalCourses.Where(optionalCourse => optionalCourse.CourseId == optionalCourseApproveDto.CourseId).FirstOrDefaultAsync();

            optionalCourse.Approved = optionalCourseApproveDto.Approved;

            _context.OptionalCourses.Update(optionalCourse);

            await _context.SaveChangesAsync();

            return optionalCourse;
        }
    }
}