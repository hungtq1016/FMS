using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Infrastructure
{
    public interface IRepository<T> where T : AbstractEntity
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetAsync(string id);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);  

    }

    public class Repository<T> : IRepository<T> where T : AbstractEntity
    {
        private readonly SharedContext _context;
        private DbSet<T> _entity;

        public Repository(SharedContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _entity.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _entity.Remove(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> records = await _entity.ToListAsync();

            return records;
        }

        public async Task<T> GetAsync(string id)
        {
            T record = await _entity.FindAsync(id);

            return record;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
