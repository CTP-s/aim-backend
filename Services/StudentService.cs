using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<GradesDto>> GetStudentGrades(int id)
        {
            var grades = new List<GradesDto>();

            await _context.Grades.Where(grade => grade.StudentId == id).ForEachAsync(grade =>
            {
                grades.Add(new GradesDto
                {
                    CourseId = grade.CourseId,
                    Value = grade.Value
                });
            });

            if (grades.Count == 0) return null;

            return grades;
        }

        private async Task<int> _getCurriculumByCourse(int courseId)
        {
            var course = await _context.RegularCourses.Where(course => course.CourseId == courseId).FirstOrDefaultAsync();

            if (course == null) return -1;

            return course.CurriculumId;
        }

        public async Task<IList<StudentDto>> GetStudentsByCourse(int courseId)
        {
            var curriculumId = await _getCurriculumByCourse(courseId);

            if (curriculumId < 0) return null;

            var students = new List<StudentDto>();

            await _context.StudentCurricula.Where(studCurriculum => studCurriculum.CurriculumId == curriculumId).ForEachAsync(async result =>
            {
                var student = await _context.Students.Where(student => student.Id == result.StudentId).FirstOrDefaultAsync();
                var studentDto = _mapper.Map<StudentDto>(student);
                students.Add(studentDto);
            });

            if (students.Count == 0) return null;

            return students;
        }

        public async Task<StudentInfoDto> GetStudentInfo(int id)
        {
            var student = await _context.Users.Where(user => user.Id == id).FirstOrDefaultAsync();

            if (student == null) return null;

            var studentInfoDto = new StudentInfoDto
            {
                StudentId = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                UserName = student.UserName,
                Email =student.Email,
                CNP = student.CNP,
                Address = student.Address,
                Hometown = student.Hometown
            };

            return studentInfoDto;
        }
    }

}