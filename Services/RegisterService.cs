using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.DTOs;
using aim_backend.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace aim_backend.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RegisterService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> PostUser(UserCredentialsDto userCredentials)
        {
            if (await userExists(userCredentials.email)) return null;

            User user;

            if (userCredentials.discriminator.ToLower() == "student")
            {
                user = new Student();
                user = _mapper.Map<Student>(userCredentials);
            }
            else 
            {
                user = new Teacher();
                user = _mapper.Map<Teacher>(userCredentials);
            }

            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private async Task<bool> userExists(string email)
        {
            return await _context.Users.AnyAsync(user => user.email.ToLower() == email.ToLower());
        }
    }
}