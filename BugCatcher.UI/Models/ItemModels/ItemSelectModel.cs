using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BugCatcher.UI.Models.ItemModels
{
    public class ItemSelectModel
    {
        public ItemEntity Item { get; set; }
        public IEnumerable<SelectListItem> ProjectSelect { get; set; }
        public IEnumerable<SelectListItem> PrioritySelect { get; set; }
        public IEnumerable<SelectListItem> TeamSelect { get; set; }
        public IEnumerable<SelectListItem> AssignedUserSelect { get; set; }
        public IEnumerable<SelectListItem> StageSelect { get; set; }
        public IEnumerable<SelectListItem> StatusSelect { get; set; }
        public IEnumerable<SelectListItem> SprintSelect { get; set; }
    }
}
