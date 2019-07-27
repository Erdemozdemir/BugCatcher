using BugCatcher.Entities.CustomDataAnnotation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    [Table("ItemFiles")]
    public class ItemFileEntity : EntityBase
    {
        [Required, StringLength(4000),  Display(Order = 1)]
        public string FileName { get; set; }

        [Required, ShowInFilter, Display(Order = 2)]
        public virtual ItemEntity Item { get; set; }
    }
}
