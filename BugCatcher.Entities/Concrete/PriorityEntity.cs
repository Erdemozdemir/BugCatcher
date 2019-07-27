using BugCatcher.Entities.CustomDataAnnotation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    [Table("Priority")]
    public class PriorityEntity : EntityBase
    {
        [Required, StringLength(50),ShowInFilter,Display(Order =1)]
        public string Name { get; set; }

        [Required, ShowInFilter, Display(Order = 2)]
        public int Level { get; set; }
    }
}
