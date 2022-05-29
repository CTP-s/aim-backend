using System.Collections.Generic;
using System.Threading.Tasks;
using aim_backend.DTOs;
using aim_backend.Models;

namespace aim_backend.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetUserList();

        Task<User> GetUser(int id);

        Task<UserUpdateDTO> UpdateUserInfo(UserUpdateDTO userUpdateDTO);
    }
}