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
    }

}