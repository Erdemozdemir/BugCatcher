using BugCatcher.Entities.CustomDataAnnotation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    [Table("ItemComments")]
    public class ItemCommentsEntity : EntityBase
    {
        [Required, StringLength(4000), ShowInFilter, Display(Order = 1)]
        public string Comment { get; set; }
        [Required, ShowInFilter, Display(Order = 2)]
        public virtual ItemEntity Item { get; set; }

    }
}
