using BugCatcher.Entities.CustomDataAnnotation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugCatcher.Entities.Concrete
{
    [Table("Item")]
    public class ItemEntity : EntityBase
    {
        [Required, StringLength(250), ShowInFilter, Display(Order = 1)]
        public string Title { get; set; }
        public DateTime Deadline{ get; set; }

        [ShowInFilter, Display(Order = 2)]
        public virtual ProjectEntity Project { get; set; }
        [ShowInFilter, Display(Order = 4)]
        public virtual PriorityEntity Priority { get; set; }
        [ShowInFilter, Display(Order = 3)]
        public virtual TeamEntity Team { get; set; }
        [ShowInFilter, Display(Order = 5)]
        public virtual UserEntity AssignedUser { get; set; }
        [Display(Order = 6)]
        public virtual UserEntity LastUpdatedUser { get; set; }
        [ShowInFilter, Display(Order = 7)]
        public virtual StageEntity Stage { get; set; }
        [ShowInFilter, Display(Order = 8)]
        public virtual StatusEntity Status { get; set; }
        [ShowInFilter, Display(Order = 9)]
        public virtual SprintEntity Sprint { get; set; }
    }
}
