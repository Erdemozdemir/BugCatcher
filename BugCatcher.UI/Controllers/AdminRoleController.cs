using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BugCatcher.UI.Controllers
{
    public class AdminRoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public AdminRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        #region Roles

        public ActionResult RoleList()
        {

            return View(_roleManager.Roles);
        }

        public ActionResult NewRole()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRole(string name)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {return RedirectToAction("RoleList"); }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View(name);
        }

        public async Task<IActionResult> DeleteRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null) return BadRequest();

            var result = _roleManager.DeleteAsync(role);
            return RedirectToAction("RoleList");

        }

        #endregion

    }
}