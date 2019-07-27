using Microsoft.AspNetCore.Mvc;

namespace BugCatcher.UI.Controllers
{
    public class ViewComponentController : Controller
    {
        public IActionResult GetCommentsAndFiles(int id)
        {
            return ViewComponent("CommentsAndFile", new { id});
        }

        public IActionResult GetUserRoles(string id)
        {
            return ViewComponent("UserRoles", new { id });
        }
        public IActionResult GetItemSubs(string id)
        {
            return ViewComponent("ItemSubs", new { id });
        }
    }
}