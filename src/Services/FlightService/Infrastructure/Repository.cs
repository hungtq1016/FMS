using Core;
using FlightService.Infrastructure.Data;
using Infrastructure.EFCore.Repository;
using Microsoft.Extensions.Caching.Memory;

namespace FlightService.Infrastructure
{
    public class FlightRepository<TEntity> : RepositoryBase<FlightContext, TEntity> where TEntity : Entity
    {
        public FlightRepository(FlightContext context, IMemoryCache cache) : base(context, cache)
        {
        }
    }
}
