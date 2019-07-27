using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BugCatcher.UI.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        public Task<UserEntity> CurrentUser
        {
            get { return GetCurrentUser(); }
        }

        public BaseController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        protected async Task<UserEntity> GetCurrentUser()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = await _userManager.GetUserAsync(currentUser);
            return user;
        }
    }
}