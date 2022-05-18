using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.DTOs;
using aim_backend.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        
        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<User> GetUser(int id)
        {
            User user = await _context.Users.FindAsync(id);
            return _mapper.Map<User>(user);
        }

        public async Task<IList<User>> GetUserList()
        {

            return await _context.Users.ToListAsync();
        }
        
    }
}