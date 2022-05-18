using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.DTOs;

namespace aim_backend.Services
{
    public interface IDisciplineService
    {
        Task<IList<DisciplineDTO>> GetDisciplines();
    }
}