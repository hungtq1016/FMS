using Share.Entities;

namespace Service
{
    public interface IService<T> where T : AbstractEntity
    {
        Task<Response<T>> GetAsync(string id);
        Task<Response<List<T>>> GetAllAsync();
        Task<Response<T>> PostAsync (T entity);
        Task<Response<T>> PutAsync (T entity);
        Task<Response<bool>> DeleteAsync (string id);
    }

    public class Service<T> : IService<T> where T : AbstractEntity
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<T>>> GetAllAsync()
        {
            List<T> list = await _repository.GetAllAsync();

            if (list.Count is 0)
            {
                return new Response<List<T>>
                {
                    Data = list,
                    IsError = true,
                    StatusCode = 404,
                    Message = "Not Found!"
                };
            }

            return new Response<List<T>>
            {
                Data = list,
                IsError = false,
                StatusCode = 200,
                Message = "Success!"
            };
        }

        public async Task<Response<T>> GetAsync(string id)
        {
            T item = await GetByIdAsync(id);

            if (item is null)
            {
                return new Response<T>
                {
                    Data = default(T),
                    IsError = true,
                    StatusCode = 404,
                    Message = "Not Found!"
                };
            }

            return new Response<T>
            {
                Data = item,
                IsError = false,
                StatusCode = 200,
                Message = "Success!"
            };
        }

        public async Task<Response<T>> PostAsync(T entity)
        {
            await _repository.CreateAsync(entity);

            return new Response<T>
            {
                Data = entity,
                IsError = false,
                StatusCode = 201,
                Message = "Created!"
            };
        }

        public async Task<Response<T>> PutAsync(T entity)
        {
            T item = await GetByIdAsync(entity.Id);

            if (item is null)
            {
                return new Response<T>
                {
                    Data = default(T),
                    IsError = true,
                    StatusCode = 404,
                    Message = "Not Found!"
                };
            }

            await _repository.UpdateAsync(entity);

            return new Response<T>
            {
                Data = entity,
                IsError = false,
                StatusCode = 200,
                Message = "Updated!"
            };

        }
        public async Task<Response<bool>> DeleteAsync(string id)
        {
            T item = await GetByIdAsync(id);

            if (item is null)
            {
                return new Response<bool>
                {
                    Data = default(bool),
                    IsError = true,
                    StatusCode = 404,
                    Message = "Not Found!"
                };
            }

            await _repository.DeleteAsync(item);

            return new Response<bool>
            {
                Data = true,
                IsError = false,
                StatusCode = 200,
                Message = "Updated!"
            };
        }

        private async Task<T> GetByIdAsync(string id)
        {
            return await _repository.GetAsync(id);
        }
    }
}
