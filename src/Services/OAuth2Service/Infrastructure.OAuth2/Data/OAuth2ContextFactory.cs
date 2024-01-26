using Infrastructure.EFCore.Data;

namespace Infrastructure.OAuth2.Data
{
    public class OAuth2ContextFactory : AppDbContextFactory<OAuth2Context>
    {
        public OAuth2ContextFactory() : base("userDB")
        {
        }
    }
}
