using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using System.Collections.Generic;

namespace BugCatcher.BusinessLayer.Managers.Abstract
{
    public interface ICommentRepository : IGenericRepository<ItemCommentsEntity>
    {
        List<ItemCommentsEntity> GetActiveItemComments(int itemId);
        ItemCommentsEntity GetItemIncludedComment(int commentId);
    }
}
