using System;
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
    public class DisciplineService : IDisciplineService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DisciplineService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<IList<DisciplineDTO>> GetDisciplines()
        {
            var regularDisciplines = await _context.RegularCourses.ToListAsync();
            var optionalDisciplines = await _context.OptionalCourses.ToListAsync();

            var disciplines = new List<DisciplineDTO>();

            regularDisciplines.ForEach(async course =>
            {
                var lecturer = await _context.Teachers.Where(user => user.Id == course.TeacherId).FirstOrDefaultAsync();

                var mean = await GetDisciplineMean(course.CourseId);

                disciplines.Add(new DisciplineDTO
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    CourseSemester = course.Semester,
                    Discriminator = "Regular",
                    LecturerId = lecturer.Id,
                    LecturerFirstName = lecturer.FirstName,
                    LecturerLastName = lecturer.LastName,
                    DisciplineMean = mean
                });
            });

            optionalDisciplines.ForEach(async course =>
              {
                  var lecturer = await _context.Teachers.Where(user => user.Id == course.TeacherId).FirstOrDefaultAsync();

                  var mean = await GetDisciplineMean(course.CourseId);

                  disciplines.Add(new DisciplineDTO
                  {
                      CourseId = course.CourseId,
                      CourseName = course.CourseName,
                      CourseSemester = course.Semester,
                      Discriminator = "Optional",
                      LecturerId = lecturer.Id,
                      LecturerFirstName = lecturer.FirstName,
                      LecturerLastName = lecturer.LastName,
                      DisciplineMean = mean
                  });
              });

            if (disciplines.Count == 0) return null;

            return disciplines;
        }

        public async Task<DisciplineDTO> SetMaxStudentsOptionalCourse(DisciplineUpdateDTO disciplineUpdateDTO)
        {
            var optionalCourse = await _context.OptionalCourses.FindAsync(disciplineUpdateDTO.CourseId);

            if (optionalCourse == null) return null;

            optionalCourse.MaxNumberStudents = disciplineUpdateDTO.MaximumNumberOfStudents;

            _context.OptionalCourses.Update(optionalCourse);
            await _context.SaveChangesAsync();

            var disciplineDto = _mapper.Map<DisciplineDTO>(optionalCourse);

            return disciplineDto;
        }

        private async Task<float> GetDisciplineMean(int disciplineId)
        {
            float sum = 0, total = 0;
            await _context.Grades.Where(grade => grade.CourseId == disciplineId).ForEachAsync(grade =>
            {
                sum = sum + grade.Value;
                total = total + 1;
            }
            );

            if (total == 0) return -1;

            return sum / total;
        }


        public async Task<IList<RegularCourseCurriculumDTO>> GetRegularDisciplinesByCurriculum(int curriculumId)
        {
            var regularDisciplines = new List<RegularCourseCurriculumDTO>();

            await _context.RegularCourses.Where(course => course.CurriculumId == curriculumId).ForEachAsync(async course =>
            {
                var lecturer = await _context.Teachers.Where(teacher => teacher.Id == course.TeacherId).FirstOrDefaultAsync();

                regularDisciplines.Add(new RegularCourseCurriculumDTO
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    CourseSemester = course.Semester,
                    LecturerFirstName = lecturer.FirstName,
                    LecturerLastName = lecturer.LastName
                });
            });

            if (regularDisciplines.Count == 0) return null;

            return regularDisciplines;

        }

        public async Task<OptionalCourseDTO> GetOptionalCourseByStudent(int studentId)
        {
            var studentCurriculum = await _context.StudentCurricula.Where(studCurriculum => studCurriculum.StudentId == studentId)
                .FirstOrDefaultAsync();

            if (studentCurriculum == null || studentCurriculum.OptionalCourseId == 0) return null;

            int optionalCourseId = studentCurriculum.OptionalCourseId;

            var optionalCourse = await _context.OptionalCourses.Where(optionalCourse => optionalCourse.CourseId == optionalCourseId)
                .FirstOrDefaultAsync();

            var lecturer = await _context.Teachers.Where(teacher => teacher.Id == optionalCourse.TeacherId).FirstOrDefaultAsync();

            return new OptionalCourseDTO
            {
                CourseId = optionalCourseId,
                CourseName = optionalCourse.CourseName,
                CourseSemester = optionalCourse.Semester,
                LecturerFirstName = lecturer.FirstName,
                LecturerLastName = lecturer.LastName,
                MaxNumberStudents = optionalCourse.MaxNumberStudents
            };
        }

        public async Task<IList<RegularCourseCurriculumDTO>> GetRegularDisciplinesByStudentId(int studentId)
        {
            var curriculum = await _context.StudentCurricula.Where(studCurriculum => studCurriculum.StudentId == studentId)
                .FirstOrDefaultAsync();

            if (curriculum == null) return null;

            var regularCourses = await GetRegularDisciplinesByCurriculum(curriculum.CurriculumId);

            if (regularCourses == null) return null;

            return regularCourses;
        }

        // public async Task<IList<DisciplineDTO>> GetDisciplinesByLecturer(int teacherId)
        // {
        //     var lecturerDisciplines = new List<DisciplineDTO>();
        //     await _context.RegularCourses.Where(course => course.TeacherId == teacherId).ForEachAsync( course => {
        //         lecturerDisciplines.Add(new DisciplineDTO {
        //             CourseId = course.CourseId,
        //             CourseName = course.CourseName,
        //             CourseSemester = course.Semester,

        //         });
        //     });

        // }
    }
}