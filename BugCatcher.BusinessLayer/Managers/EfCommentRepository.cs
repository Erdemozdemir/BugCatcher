using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfCommentRepository : EfGenericRepository<ItemCommentsEntity>, ICommentRepository
    {
        public List<ItemCommentsEntity> GetActiveItemComments(int itemId)
        {
            var list = GetList(x => x.Item.Id == itemId).Where(x=>x.IsActive==true).OrderBy(x => x.CreDate);
            return list.ToList();
        }

        public ItemCommentsEntity GetItemIncludedComment(int commentId)
        {
            var comment = _context.ItemComments
                        .Include(x => x.Item)
                        .FirstOrDefault(x => x.Id == commentId);
            return comment;
        }
    }
}
