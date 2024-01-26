using Core;
using Infrastructure.EFCore.Repository;

namespace Infrastructure.OAuth2.Data
{
    public class Repository<TEntity> : RepositoryBase<OAuth2Context, TEntity> where TEntity : Entity, IAggregateRoot
    {
        public Repository(OAuth2Context dbContext) : base(dbContext)
        {
        }
    }
}
