using Core;
using Infrastructure.EFCore.Repository;
using Microsoft.Extensions.Caching.Memory;
using UserService.Infrastructure.Data;

namespace UserService.Infrastructure
{
    public class UserRepository<TEntity> : RepositoryBase<UserContext, TEntity> where TEntity : Entity
    {
        public UserRepository(UserContext context, IMemoryCache cache) : base(context, cache)
        {
        }
    }
}
