using System;
using System.ComponentModel.DataAnnotations;

namespace BugCatcher.UI.Models.ItemModels
{
    public class ItemCreateModel
    {
        [Required]
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int PriorityId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int AssignedUserId { get; set; }
        [Required]
        public int StageId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int SprintId { get; set; }
    }
}
