using Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Infrastructure.EFCore.Data
{
    public class AppDbContext : DbContext, IDomainEventContext, IDbFacadeResolver
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        protected AppDbContext(){}

        public IEnumerable<IDomainEvent> GetDomainEvents()
        {
            var domainEntities = ChangeTracker
                .Entries<EntityRootBase>()
                .Where(x =>
                    x.Entity.DomainEvents != null &&
                    x.Entity.DomainEvents.Any())
                .ToImmutableList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToImmutableList();

            domainEntities.ForEach(entity => entity.Entity.DomainEvents.Clear());

            return domainEvents;
        }
    }
}
