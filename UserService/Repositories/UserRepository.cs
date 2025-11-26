using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _ctx;
        public UserRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(User user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
           return await _ctx.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.Email == email);
            
        }
           

        public async Task<User?> GetByIdAsync(Guid userId)
        {
          return  await _ctx.Users.Include(u => u.RefreshTokens).FirstOrDefaultAsync(u => u.UserId == userId);

        }

        public async Task UpdateAsync(User user) {
            _ctx.Users.Update(user);

            await _ctx.SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(string token)
        {
          return  await _ctx.RefreshTokens.Include(r => r.User).FirstOrDefaultAsync(r => r.Token == token);

        }

        public async Task AddRefreshTokenAsync(RefreshToken token) => await _ctx.RefreshTokens.AddAsync(token);

        public async Task RevokeRefreshTokenAsync(RefreshToken token)
        {
            token.Revoked = true;
            _ctx.RefreshTokens.Update(token);
            await _ctx.SaveChangesAsync();
        }
    }
}
