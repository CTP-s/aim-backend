using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Models;

namespace aim_backend.Services
{
    public interface ILoginService
    {
        Task<User> VerifyUserCredentials(UserLoginDto userLogin);

        Task<UserLoginResponseDto> Login(User user);
    }
}