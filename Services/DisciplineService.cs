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

    }
}