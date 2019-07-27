using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using System.Collections.Generic;

namespace BugCatcher.BusinessLayer.Managers.Abstract
{
    public interface IItemSubscriberRepository:IGenericRepository<ItemSubscribersEntity>
    {
        IEnumerable<UserEntity> GetItemSubscribersOrNull(int itemId);
        bool IsUserSubscribedAlready(int itemId,string userId);
    }
}
