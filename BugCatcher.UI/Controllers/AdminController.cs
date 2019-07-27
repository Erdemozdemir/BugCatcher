using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using BugCatcher.UI.Models;
using BugCatcher.UI.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugCatcher.UI.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private UserManager<UserEntity> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ILogRepository _logRepo;
        private IPasswordHasher<UserEntity> _passwordHasher;
        private IPasswordValidator<UserEntity> _passwordValidator;
        private SignInManager<UserEntity> _signInManager;

        public AdminController(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager, IPasswordHasher<UserEntity> passwordHasher, IPasswordValidator<UserEntity> passwordValidator, ILogRepository logRepo, SignInManager<UserEntity> signInManager):base(userManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _logRepo = logRepo;
            _passwordHasher = passwordHasher;
            _passwordValidator = passwordValidator;
            _signInManager = signInManager;
        }

        #region User
        public IActionResult UserList()
        {

            return View(_userManager.Users.ToList());
        }

        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewUser(UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                userEntity.PasswordHash = _passwordHasher.HashPassword(userEntity, userEntity.PasswordHash);
                userEntity.SecurityStamp = Guid.NewGuid().ToString();
                userEntity.CreUser = await CurrentUser;
                userEntity.CreDate = DateTime.Now;
                var result = await _userManager.CreateAsync(userEntity, userEntity.PasswordHash);
                if (result.Succeeded)
                    return RedirectToAction("UserList");
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return View(userEntity);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
                return View(user);
            else
                return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string PasswordHash, string email)
        {
            UserEntity userEntity = new UserEntity();
            if (ModelState.IsValid)
            {
                userEntity = await _userManager.FindByIdAsync(id);
                var validPass = await _passwordValidator.ValidateAsync(_userManager, userEntity, PasswordHash);

                if (validPass.Succeeded)
                {
                    userEntity.PasswordHash = _passwordHasher.HashPassword(userEntity, PasswordHash);
                    userEntity.ModUser = (await CurrentUser).UserName;
                    userEntity.ModDate = DateTime.Now;
                    var result = await _userManager.UpdateAsync(userEntity);

                    if (result.Succeeded)
                        RedirectToAction("UserList");
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var item in validPass.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

                return RedirectToAction("UserList");
            }

            return View(userEntity);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                user.ModDate = DateTime.Now;
                user.ModUser = (await CurrentUser).UserName;
                await _userManager.DeleteAsync(user);
                return RedirectToAction("UserList");
            }
            else
                return BadRequest();
        }
        #endregion

        public async Task<ActionResult> UserRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var roles = _roleManager.Roles.Where(x => !userRoles.Contains(x.Name));

            List<SelectListItem> rolesList = new List<SelectListItem>();
            if (roles.Count() > 0)
            {

                rolesList = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).ToList();
                rolesList.Insert(0, new SelectListItem { Text = "Choose a role", Value = "0", Selected = true, Disabled = true });
            }

            UserRoleModel userRoleModel = new UserRoleModel
            {
                Roles = rolesList,
                User = user
            };

            return View(userRoleModel);
        }

        [HttpPost]
        public async Task<ActionResult> UserRole(string userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.AddToRoleAsync(user, roleName);
                var userRoles = await _userManager.GetRolesAsync(user);

                var roles = _roleManager.Roles.Where(x => !userRoles.Contains(x.Name));
                List<SelectListItem> rolesList = new List<SelectListItem>();
                if (roles.Count() > 0)
                {

                    rolesList = roles.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).ToList();
                    rolesList.Insert(0, new SelectListItem { Text = "Choose a role", Value = "0", Selected = true, Disabled = true });
                }

                UserRoleModel userRoleModel = new UserRoleModel
                {
                    Roles = rolesList,
                    User = user
                };

                return View(userRoleModel);

                //if (result.Succeeded)
                //{
                //    _logRepo.LogInfo($"{roleName} added to {user.UserName}", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);

                //    Response.StatusCode = (int)HttpStatusCode.OK;

                //    return Json("Role Added!");
                //}
                //else
                //{
                //    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //    _logRepo.LogInfo("Role cant be added for some reason!", Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                //    return Json("Role cant be added for some reason!");
                //}

            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return View(null);
            }
        }

        public async Task<ActionResult> DeleteUserRole(string userId, string roleName)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);

                if (result.Succeeded)
                {
                    _logRepo.LogInfo($"{roleName} deleted from {user.UserName}", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);

                    Response.StatusCode = (int)HttpStatusCode.OK;

                    return Json("Role Deleted!");
                }
                else
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    _logRepo.LogInfo("Role cant be deleted for some reason!", Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                    return Json("Role cant be deleted for some reason!");
                }
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return Json("There is an error! <br/>" + ex.Message);
            }
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(loginModel.Email);

                    var result = await _signInManager.PasswordSignInAsync(user,
                                        loginModel.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignOutAsync();
                        await _signInManager.SignInAsync(user, false);


                        return Redirect(returnUrl ?? "/");
                    }
                    ModelState.AddModelError("Email", "Invalid key or password");
                    return View(loginModel);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(loginModel);
        }

        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}