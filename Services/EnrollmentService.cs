using System.Linq;
using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.DTOs;
using aim_backend.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EnrollmentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Enrollment> PostEnrollment(EnrollDto enrollDto)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollDto);

            _context.Enrollments.Add(enrollment);

            var curriculum = await _context.Curriculum.Where(curriculum => curriculum.YearOfStudyId == enrollDto.YearOfStudyId).FirstOrDefaultAsync();

            var studentCurriculum = new StudentCurriculum
            {
                CurriculumId = curriculum.CurriculumId,
                StudentId = enrollDto.StudentId
            };

            _context.StudentCurricula.Add(studentCurriculum);

            await _context.SaveChangesAsync();

            return enrollment;
        }
    }
}