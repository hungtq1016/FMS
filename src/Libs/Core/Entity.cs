using System.Text.Json.Serialization;

namespace Core
{
    public interface IEntity
    {
        public Guid Id { get; }
        public bool Enable { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }
    }

    public abstract class Entity: IEntity
    {
        public Guid Id { get; }  = Guid.NewGuid();

        public bool Enable { get; } = true;

        public DateTime CreatedAt { get; } = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);

        public DateTime UpdatedAt { get; internal set; }
    }

    public interface IAggregateRoot : IEntity
    {
        public HashSet<IDomainEvent> DomainEvents { get; }
    }

    public abstract class EntityRootBase : Entity, IAggregateRoot
    {
        [JsonIgnore]
        public HashSet<IDomainEvent> DomainEvents { get; private set; }

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            DomainEvents ??= new HashSet<IDomainEvent>();
            DomainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(EventBase eventItem)
        {
            DomainEvents?.Remove(eventItem);
        }
    }

    public abstract class AbstractFile : Entity
    {
        public string Title { get; set; }

        public string? Alt { get; set; }

        public long Size { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }
    }

    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if(left is null ^ right is null)
            {
                return false;
            }

            return left.Equals(right) != false;
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}