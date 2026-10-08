using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Entities;

namespace server.Repository
{
    public interface IUserRepository
    {
        Task<User>GetUserByEmail(string email);
        Task<User?> GetUserById(int id);
        Task<bool> AddUser(User user);
        Task<List<User>>GetAllUsers();
        Task<bool> SaveRefreshToken(RefreshToken refreshToken); 
        Task<RefreshToken?> GetRefreshToken(string token); 
        Task<bool> UpdateRefreshToken(RefreshToken refreshToken);
    }
}
