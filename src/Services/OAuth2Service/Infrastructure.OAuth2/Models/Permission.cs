using Core;

namespace Infrastructure.OAuth2.Models
{
    public class Permission : EntityRootBase
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
