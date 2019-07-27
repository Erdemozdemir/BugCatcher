using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BugCatcher.UI.Models;
using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.UI.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogRepository _logRepo;
        private readonly IItemRepository _itemRepo;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IPasswordHasher<UserEntity> _passwordHasher;

        public HomeController(IItemRepository itemRepo, ILogRepository logRepo, SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager, IPasswordHasher<UserEntity> passwordHasher):base(userManager)
        {
            _logRepo = logRepo;
            _itemRepo = itemRepo;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<IActionResult> Index(int? pageNumber,int? pageSize)
        {
            try
            {
                pageSize=pageSize ?? 3;
                var items = _itemRepo.GetPagedItems();

                var pagedList=await TableRenderModel.CreateAsync(items.AsNoTracking(), pageNumber ?? 1, pageSize);


                return View(pagedList);
            }
            catch (Exception ex)
            {
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Index(TableRenderModel model)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Settings()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = await _userManager.GetUserAsync(currentUser);
            var model = new SettingModel
            {
                Username = user.UserName,
                Password = user.PasswordHash,
                Email = user.Email
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(SettingModel settingModel)
        {
            if (!ModelState.IsValid) return View(settingModel);

            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = await _userManager.GetUserAsync(currentUser);

            var hashPass = _passwordHasher.HashPassword(user, settingModel.Password);
            user.PasswordHash = hashPass;
            await _userManager.UpdateAsync(user);
            
            return View(settingModel);
        }
    }
}
