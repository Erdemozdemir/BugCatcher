using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.UI.Models.Comments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BugCatcher.UI.Components.CommentsAndFile
{
    public class CommentsAndFile : ViewComponent
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IItemFileRepository _itemFileRepo;


        public CommentsAndFile(ICommentRepository commentRepo, IItemFileRepository itemFileRepo)
        {
            _commentRepo = commentRepo;
            _itemFileRepo = itemFileRepo;
        }

        public IViewComponentResult Invoke(int id)
        {
            if (id > 0)
            {
                var comments = _commentRepo.GetActiveItemComments(id);
                var files = _itemFileRepo.GetActiveItemFiles(id);

                List<CommentFileModel> commentFileModels = new List<CommentFileModel>();

                foreach (var comment in comments)
                {
                    commentFileModels.Add(new CommentFileModel
                    {
                        Id = comment.Id,
                        Text =comment.Comment,
                        CreDate=comment.CreDate,
                        IsFile=false
                    });
                }

                foreach (var file in files)
                {
                    commentFileModels.Add(new CommentFileModel
                    {
                        Id=file.Id,
                        Text = file.FileName,
                        CreDate = file.CreDate,
                        IsFile = true
                    });
                }


                return View(commentFileModels.OrderByDescending(x=>x.CreDate));
            }

            return null;
        }
    }
}
