using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfItemSubcribersRepository : EfGenericRepository<ItemSubscribersEntity>, IItemSubscriberRepository
    {
        public bool IsUserSubscribedAlready(int itemId,string userId)
        {
            var subscriber = _context.ItemSubscribers
                .Include(u => u.User)
                .Include(p => p.Item)
                .Where(x => x.User.Id == userId&& x.Item.Id == itemId)
                .Select(x => x.User)
                .Where(x => x != null)
                .ToList();

            return subscriber != null||subscriber.Count>0;
        }

        public IEnumerable<UserEntity> GetItemSubscribersOrNull(int itemId)
        {
            var subscribers = _context.ItemSubscribers
                .Include(u => u.User)
                .Include(p => p.Item)
                .Where(x => x.Item.Id == itemId)
                .Select(x => x.User)
                .Where(x=>x != null)
                .ToList();

            if (subscribers != null)
                return subscribers;

            return null;
        }
    }
}
