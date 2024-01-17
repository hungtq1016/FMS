using Data.Data;
using BC = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using Share.Entities;

namespace Service.Repositories
{
    public interface IAuthenticateRepository
    {
        Task<bool> IsPasswordMatch(string password, User request);
        Task<User> IsEmailExist(string email);
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
    }
}
