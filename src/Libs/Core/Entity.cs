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

    public abstract class AbstractFile : Entity
    {
        public string Title { get; set; }

        public string? Alt { get; set; }

        public long Size { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }
    }
}