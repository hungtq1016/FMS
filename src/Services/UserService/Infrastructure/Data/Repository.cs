using Core;
using Infrastructure.EFCore.Repository;

namespace UserService.Infrastructure.Data
{
    public class UserRepository<TEntity> : RepositoryBase<UserContext, TEntity> where TEntity : Entity
    {
        public UserRepository(UserContext context) : base(context)
        {
        }
    }
}
