using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;

        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IList<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}