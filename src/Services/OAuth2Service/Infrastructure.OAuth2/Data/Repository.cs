using Core;
using Infrastructure.EFCore.Repository;

namespace Infrastructure.OAuth2.Data
{
    public class OAuth2Repository<TEntity> : RepositoryBase<OAuth2Context, TEntity> where TEntity : Entity
    {
        public OAuth2Repository(OAuth2Context dbContext) : base(dbContext)
        {
        }
    }
}
