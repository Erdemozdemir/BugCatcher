using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugCatcher.UI.Components.UserRoles
{
    public class UserRoles : ViewComponent
    {
        private UserManager<UserEntity> _userManager;

        public UserRoles(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            return View(userRoles);
        }
    }
}
