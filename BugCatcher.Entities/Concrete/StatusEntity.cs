using BugCatcher.Entities.CustomDataAnnotation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    [Table("Status")]
    public class StatusEntity : EntityBase
    {
        [Required, StringLength(50), ShowInFilter, Display(Order = 1)]
        public string Name { get; set; }
    }
}
