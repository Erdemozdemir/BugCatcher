using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BugCatcher.UI.Models
{
    public class UserRoleModel
    {
        public List<SelectListItem> Roles{ get; set; }

        public UserEntity  User{ get; set; }
    }
}
