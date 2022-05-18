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
                var lecturer = await _context.Users.Where(user => user.Id == course.TeacherId).FirstOrDefaultAsync();
                disciplines.Add(new DisciplineDTO
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    LecturerId = lecturer.Id,
                    LecturerFirstName = lecturer.FirstName,
                    LecturerLastName = lecturer.LastName
                });
            });

            optionalDisciplines.ForEach(async course =>
              {
                  var lecturer = await _context.Users.Where(user => user.Id == course.TeacherId).FirstOrDefaultAsync();
                  disciplines.Add(new DisciplineDTO
                  {
                      CourseId = course.CourseId,
                      CourseName = course.CourseName,
                      LecturerId = lecturer.Id,
                      LecturerFirstName = lecturer.FirstName,
                      LecturerLastName = lecturer.LastName
                  });
              });

            if (disciplines.Count == 0) return null;

            return disciplines;
        }
    }
}