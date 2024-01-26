using Core;

namespace Infrastructure.OAuth2.Models
{
    public class Role : EntityRootBase
    {
        public string Name { get; set; }
        public string Note { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
