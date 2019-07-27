using BugCatcher.Entities.CustomDataAnnotation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    public class EntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity),ShowInFilter,Display(Order =0)]
        public int Id { get; set; }

        [Required, Display(Order = 20,Name ="Is Active")]
        public bool IsActive { get; set; }

        [Required, Display(Order = 21,Name ="Creation Date")]
        public DateTime CreDate { get; set; }
        [Required, Display(Order = 22)]
        public DateTime ModDate { get; set; }
        [StringLength(30), Display(Order = 24)]
        public string ModUser { get; set; }
        public virtual UserEntity CreUser { get; set; }
    }
}
