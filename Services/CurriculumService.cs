using System.Linq;
using System.Threading.Tasks;
using aim_backend.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class CurriculumService : ICurriculumService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CurriculumService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> GetCurriculumIdByStudent(int studentId)
        {
            var curriculum = await _context.StudentCurricula.Where(curriculum => curriculum.StudentId == studentId).FirstOrDefaultAsync();

            if (curriculum == null) return -1;

            return curriculum.CurriculumId;
        }
    }
}