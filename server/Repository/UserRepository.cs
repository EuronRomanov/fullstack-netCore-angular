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
            this.contex = contex;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await this.contex.users.Where(u => u.Email == email).SingleOrDefaultAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await this.contex.users.FindAsync(id);
        }

        public async Task<bool> AddUser(User user)
        {
            await this.contex.users.AddAsync(user);
            return await this.contex.SaveChangesAsync() > 0;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await this.contex.users.ToListAsync();
        }

        public async Task<bool> SaveRefreshToken(RefreshToken refreshToken)
        {
            await this.contex.RefreshTokens.AddAsync(refreshToken);
            return await this.contex.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken?> GetRefreshToken(string token)
        {
            return await this.contex.RefreshTokens
                .Include(r => r.User)
                .SingleOrDefaultAsync(r => r.Token == token);
        }

        public async Task<bool> UpdateRefreshToken(RefreshToken refreshToken)
        {
            this.contex.RefreshTokens.Update(refreshToken);
            return await this.contex.SaveChangesAsync() > 0;
        }
    }
}
