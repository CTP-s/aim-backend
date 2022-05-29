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
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ILoginService _tokenUtils;

        public UserService(DataContext context, IMapper mapper, ILoginService tokenUtils)
        {
            _context = context;
            _mapper = mapper;
            _tokenUtils = tokenUtils;

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

        public async Task<UserUpdateDTO> UpdateUserInfo(UserUpdateDTO userUpdateDTO)
        {
            var user = await _context.Users.Where(user => user.Id == userUpdateDTO.Id).FirstOrDefaultAsync();
            
            if (user == null) return null;

            if (user.Email != userUpdateDTO.Email)
            {
                if (await _context.Users.AnyAsync(user => user.Email.ToLower() == userUpdateDTO.Email.ToLower())) return null;
            }

            user.Email = userUpdateDTO.Email;
            user.UserName = userUpdateDTO.UserName;

            _context.Update(user);

            var token = _tokenUtils.GenerateJwtToken(user, userUpdateDTO.Discriminator);

            userUpdateDTO.Token = token;

            await _context.SaveChangesAsync();

            return userUpdateDTO;
        }
    }
}