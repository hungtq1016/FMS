using Infrastructure.EFCore.Data;

namespace UserService.Infrastructure.Data
{
    public class UserContextFactory : AppDbContextFactory<UserContext>
    {
        public UserContextFactory() : base("userDB")
        {
        }
    }
}
