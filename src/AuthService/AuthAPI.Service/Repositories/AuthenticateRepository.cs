using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using AuthContext;
using BC = BCrypt.Net.BCrypt;

namespace Service.Repositories
{
    public interface IAuthenticateRepository
    {
        Task<bool> IsPasswordMatch(string password, User request);
        Task<User> IsEmailExist(string email);
        Task<User> GetUserResetPasswordAsync(string email);
    }

    public class AuthenticateRepository : IAuthenticateRepository
    {
        private readonly DataContext _context;

        public AuthenticateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> IsEmailExist(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(user => user.Email == email);

            return user;
        }

        public async Task<bool> IsPasswordMatch(string password,User request)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(user => user.Email == request.Email);

            if (user is null)
                return false;

            var result = BC.Verify(password, user.Password);

            return result;
        }

        public async Task<User> GetUserResetPasswordAsync(string email)
        {
            var record = await _context.ResetPasswords
                .Where(entity => entity.Email == email)
                .Where(entity => entity.ExpiredTime <= DateTime.UtcNow)
                .FirstOrDefaultAsync();

            if (record is null)
            {
                return null;
            }

            var user = await _context.Users.FirstOrDefaultAsync(entity => entity.Email == email);

            return user;
        }
    }
}
