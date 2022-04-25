using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using aim_backend.Data;
using aim_backend.DTOs;
using aim_backend.Helpers;
using aim_backend.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace aim_backend.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataContext _dataContext;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public LoginService(DataContext dataContext, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _dataContext = dataContext;
            _appSettings = appSettings.Value;
            _mapper  = mapper;
        }

        public async Task<User> VerifyUserCredentials(UserLoginDto userLogin)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(user => user.Email == userLogin.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password)) return null;

            return user;
        }

        public UserLoginResponseDto Login(User user)
        {   
            var token = generateJwtToken(user);

            var userLoginResponse = _mapper.Map<UserLoginResponseDto>(user);

            userLoginResponse.Token = token;

            return userLoginResponse;
        }

        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(new [] { 
                    new Claim ("id", user.Id.ToString()), 
                    new Claim ("username", user.UserName), 
                    new Claim ("email", user.Email)
                    }),  
                Expires = DateTime.Now.AddHours(48),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}