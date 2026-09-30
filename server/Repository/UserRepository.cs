using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Entities;


namespace server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContex contex;

        public UserRepository(DataContex contex)
        {
            this.contex=contex;
        }
        public async Task<User?> GetUserByEmail(string email)
        {
           return await this.contex.users.Where(u=> u.Email==email).SingleOrDefaultAsync();
        }

        async Task<bool> IUserRepository.AddUser(User user)
        {
            await this.contex.users.AddAsync(user);
            return await this.contex.SaveChangesAsync() > 0 ? true : false;
        }

        
    }
}