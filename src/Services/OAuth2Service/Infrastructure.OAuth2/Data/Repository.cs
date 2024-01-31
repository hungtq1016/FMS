using Core;
using Infrastructure.EFCore.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.OAuth2.Data
{
    public class OAuth2Repository<TEntity> : RepositoryBase<OAuth2Context, TEntity> where TEntity : Entity
    {
        public OAuth2Repository(OAuth2Context context, IMemoryCache cache) : base(context, cache)
        {
        }
    }
}
