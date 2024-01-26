using Core;
using System.Linq.Expressions;

namespace Infrastructure.EFCore.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions, CancellationToken cancellationToken = default);
        Task<List<TEntity>> FindAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
