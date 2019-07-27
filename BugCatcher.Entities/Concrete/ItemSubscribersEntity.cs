using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    [Table("ItemSubscribers")]
    public class ItemSubscribersEntity : EntityBase
    {
        public virtual ItemEntity Item{ get; set; }
        public virtual UserEntity User { get; set; }
    }
}
