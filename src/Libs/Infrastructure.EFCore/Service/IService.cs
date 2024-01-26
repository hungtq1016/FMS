using Core;
using Infrastructure.EFCore.DTOs;
using System.Linq.Expressions;

namespace Infrastructure.EFCore.Service
{
    public interface IService<TEntity> where TEntity : Entity
    {
        Task<Response<List<TEntity>>> FindAllAsync();
        Task<Response<TEntity>> FindByIdAsync(Guid id);
        Task<Response<TEntity>> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions);
        Task<Response<TEntity>> AddAsync(TEntity entity);
        Task<Response<TEntity>> EditAsync(TEntity entity);
        Task<Response<bool>> DeleteAsync(Guid id);
    }
}
