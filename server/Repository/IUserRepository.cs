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
        Task<bool> AddUser(User user);
    }
}