using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    [Table("ProjectSubscribers")]
    public class ProjectSubscribersEntity : EntityBase
    {
        public virtual ProjectEntity Project{ get; set; }
        public virtual UserEntity User { get; set; }
    }
}
