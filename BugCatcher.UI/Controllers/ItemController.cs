using BugCatcher.BusinessLayer.Managers;
using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using BugCatcher.WebApplication.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BugCatcher.UI.Controllers
{
    [Authorize]
    public class ItemController : BaseController
    {
        private readonly ILogRepository _logRepo;
        private readonly IItemRepository _itemRepo;
        private readonly UserManager<UserEntity> _userManager;
        private readonly ICommentRepository _commentRepo;
        private readonly IItemFileRepository _itemFileRepo;
        private readonly IItemSubscriberRepository _itemSubsRepo;

        public ItemController(IItemRepository itemRepo, ICommentRepository commentRepo, IItemFileRepository itemFileRepo, IItemSubscriberRepository itemSubsRepo, ILogRepository logRepo, UserManager<UserEntity> userManager):base(userManager)
        {
            _logRepo = logRepo;
            _itemRepo = itemRepo;
            _userManager = userManager;
            _commentRepo = commentRepo;
            _itemFileRepo = itemFileRepo;
            _itemSubsRepo = itemSubsRepo;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemEntity item, string comment)
        {
            try
            {
                var ads= new ItemEntity
                {
                    Project = new ProjectEntity()
                };
                //TODO
                //if (!ModelState.IsValid) return View(item);

                var itemId = _itemRepo.Add(item);

                if (!string.IsNullOrEmpty(comment))
                {
                    var commentEntity = new ItemCommentsEntity();
                    commentEntity.Comment = comment;
                    commentEntity.Item = item;
                    commentEntity.CreUser = await CurrentUser;
                    _commentRepo.Add(commentEntity);
                }

                _logRepo.LogInfo($"{item.Title} Saved.", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);

                var user = await _userManager.FindByIdAsync(item.AssignedUser.Id);
                if (user != null)
                {
                    var email = user.Email;

                    await MailHelper.SendMailAsync("BUG CATCHER", "Yeni bir item atandı.", null, itemId, user.Email);
                }

                Response.Redirect("/" + Url.FriendlyUrl(item.Title) + "/" + item.Id);
                return View(item);
            }
            catch (Exception ex)
            {
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return View();
            }
        }


        [HttpGet]
        public IActionResult Edit(string Title, int ID)
        {
            try
            {
                TempData["ItemId"] = ID;
                var item = _itemRepo.Get(x => x.Id == ID);

                _logRepo.LogInfo($"{Title} Edited.", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);

                return View(item);
            }
            catch (Exception ex)
            {
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return View();
            }

        }


        [HttpPost]
        public async Task<IActionResult> Edit(ItemEntity item, string comment)
        {
            try
            {
                //TODO
                //if (!ModelState.IsValid) return View(item);

                TempData["ItemId"] = item.Id;
                _itemRepo.Update(item);

                if (!string.IsNullOrEmpty(comment))
                {
                    var commentEntity = new ItemCommentsEntity();
                    commentEntity.Comment = comment;
                    commentEntity.Item = item;
                    commentEntity.CreUser =await CurrentUser;
                    _commentRepo.Add(commentEntity);

                    _logRepo.LogInfo($"{item.Title} Edited.", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);
                }

                var user = await _userManager.FindByIdAsync(item.AssignedUser.Id);
                if (user != null)
                    await MailHelper.SendMailAsync("BUG CATCHER", $"{item.Title}", null, item.Id, user.Email);

                return RedirectToAction("Index","Home");
            }
            catch (Exception ex)
            {
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return View(item);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int id, IList<IFormFile> files)
        {
            try
            {
                foreach (IFormFile source in files)
                {
                    string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

                    filename = DateTime.Now.ToString("ddMMyyyy") + new FileHelper().EnsureCorrectFilename(filename);

                    using (FileStream output = System.IO.File.Create(new FileHelper().GetPathAndFilename(filename)))
                        await source.CopyToAsync(output);

                    var fileEntity = new ItemFileEntity
                    {
                        FileName = filename,
                        Item = _itemRepo.Get(x => x.Id == id)
                };

                    _logRepo.LogInfo($"Item with {id} ID Uploaded a file.", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);
                    new EfItemFileRepository().Add(fileEntity);
                }

                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json("File Uploaded!");

            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return Json("There is an error! <br/>" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> DeleteFileOrComment(int id, bool isFile)
        {
            try
            {
                if (isFile)
                {
                    var file = _itemFileRepo.GetItemFileIncludeItem(id);
                    file.ModUser=(await CurrentUser).UserName;
                    _itemFileRepo.Delete(file);
                }
                else
                {
                    var comment = _commentRepo.GetItemIncludedComment(id);
                    comment.ModUser = (await CurrentUser).UserName;
                    _commentRepo.Delete(comment);

                    _logRepo.LogInfo($"{id} {(isFile ? "File" : "Comment")} deleted.", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);
                }

                Response.StatusCode = (int)HttpStatusCode.OK;

                return Json(isFile ? "File" : "Comment" + " Deleted!");
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return Json("There is an error! <br/>" + ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddSubs(int itemId, string userId)
        {
            try
            {
                var item = _itemRepo.Get(x => x.Id == itemId);
                var user = await _userManager.FindByIdAsync(userId);

                if(_itemSubsRepo.IsUserSubscribedAlready(itemId, userId))
                {
                    Response.StatusCode = (int)HttpStatusCode.OK;

                    return Json("Subscriber Already Added!");
                }
                

                var itemSubEntity = new ItemSubscribersEntity
                {
                    Item = item,
                    User = user,
                    CreUser = await CurrentUser,
                    ModUser =(await CurrentUser).UserName
                };
                _itemSubsRepo.Add(itemSubEntity);
                _logRepo.LogInfo($"Item with {itemId} ID  added User {userId}", Request.Path, Microsoft.Extensions.Logging.LogLevel.Information);

                Response.StatusCode = (int)HttpStatusCode.OK;

                return Json("Subscriber Added!");
            }
            catch (Exception ex)
            {
                var mes = ex.Message;
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logRepo.LogError(ex, Request.Path, Microsoft.Extensions.Logging.LogLevel.Error);
                return Json("There is an error! <br/>" + ex.Message);
            }
        }

    }
}