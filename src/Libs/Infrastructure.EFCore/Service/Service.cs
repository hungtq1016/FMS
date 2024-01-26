using Core;
using Infrastructure.EFCore.DTOs;
using Infrastructure.EFCore.Repository;
using System.Linq.Expressions;
using Infrastructure.EFCore.Helpers;
using Azure.Core;

namespace Infrastructure.EFCore.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : Entity
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository) 
        {
            _repository = repository;
        }

        public async Task<Response<List<TEntity>>> FindAllAsync()
        {
            var records = await _repository.FindAllAsync();

            if (records is null)
                return ResponseHelper.CreateNotFoundResponse<List<TEntity>>(null);

            records = records.Where(record => record.Enable).ToList();

            return ResponseHelper.CreateSuccessResponse(records);
        }


        public async Task<Response<TEntity>> FindByIdAsync(Guid id)
        {
            TEntity record = await _repository.FindByIdAsync(id);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<TEntity>(null);


            return ResponseHelper.CreateSuccessResponse(record);
        }


        public async Task<Response<TEntity>> FindOneAsync(Expression<Func<TEntity, bool>>[] conditions)
        {
            TEntity record = await _repository.FindOneAsync(conditions);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<TEntity>(null);


            return ResponseHelper.CreateSuccessResponse(record);
        }


        public async Task<Response<TEntity>> AddAsync(TEntity entity)
        {
            var record = await _repository.AddAsync(entity);

            return ResponseHelper.CreateCreatedResponse(record);
        }


        public async Task<Response<bool>> DeleteAsync(Guid id)
        {
            var record = await _repository.FindByIdAsync(id);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<bool>(null);

            await _repository.DeleteAsync(record);

            return ResponseHelper.CreateSuccessResponse(true);
        }


        public async Task<Response<TEntity>> EditAsync(TEntity entity)
        {
            var record = await _repository.FindByIdAsync(entity.Id);

            if (record is null)
                return ResponseHelper.CreateNotFoundResponse<TEntity>(null);

            await _repository.EditAsync(record);

            return ResponseHelper.CreateSuccessResponse(entity);
        }
    }
}
