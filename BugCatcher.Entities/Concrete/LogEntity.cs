using System.ComponentModel.DataAnnotations;

namespace BugCatcher.Entities.Concrete
{
    public class LogEntity:EntityBase
    {
        [Required, Display(Order = 2)]
        public virtual UserEntity User { get; set; }

        [Required, StringLength(500), Display(Order = 3)]
        public string Message { get; set; }

        [Required, StringLength(500), Display(Order = 4)]
        public string Url { get; set; }

        [Display(Order = 5)]
        public int Level { get; set; }

        [StringLength(20), Display(Order = 6)]
        public string IP { get; set; }
    }
}
