using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Models;

namespace aim_backend.Services
{
    public interface IRegisterService
    {
        Task<User> GetUserById(int id); 
        Task<User> PostUser(UserCredentialsDto user);    
    }
}