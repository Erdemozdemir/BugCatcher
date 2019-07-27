using BugCatcher.BusinessLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BugCatcher.UI.Components.UserRoles
{
    public class ItemSubs : ViewComponent
    {
       
        public IViewComponentResult Invoke(string id)
        {
            var users = new EfItemSubcribersRepository().GetItemSubscribersOrNull(Convert.ToInt32(id));

            if (users == null) return null;

            return View(users);
        }
    }
}
