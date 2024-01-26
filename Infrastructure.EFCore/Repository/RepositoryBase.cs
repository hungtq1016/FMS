using Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.EFCore.Repository
{
    public abstract class RepositoryBase<TDbContext, TEntity> : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
        where TDbContext : DbContext
    {
        protected readonly TDbContext _context;
        protected readonly DbSet<TEntity> _entity;

        protected RepositoryBase(TDbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entity.ToListAsync(cancellationToken: cancellationToken);
        }

        public async Task<TEntity> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _entity.SingleOrDefaultAsync(e => e.Id == id, cancellationToken: cancellationToken);
        }

        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> query = _entity;

            foreach (var condition in conditions)
            {
                query = query.Where(condition);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _entity.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async ValueTask DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _entity.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> EditAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = _context.Entry(entity);

            entry.State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(entry.Entity);
        }
    }
}