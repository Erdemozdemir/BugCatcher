using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfItemRepository : EfGenericRepository<ItemEntity>, IItemRepository
    {
        [Obsolete("Will be deleted")]
        public List<ItemEntity> GetItemsByUser(Expression<Func<ItemEntity, bool>> filter = null)
        {
            return null;
        }

        public List<ItemEntity> GetIncludedItems(Expression<Func<ItemEntity, bool>> filter = null)
        {
            var query = _context.Items
                        .Include(x => x.Project)
                        .Include(x => x.Priority)
                        .Include(x => x.Status)
                        .Include(x => x.Stage)
                        .Include(x => x.Sprint)
                        .Include(x => x.Team)
                        .Include(x => x.AssignedUser);
            if (filter == null)
                return query.ToList();

            return query.Where(filter).ToList();
        }

        public List<ItemEntity> GetItemsCommentsAndFiles(int id)
        {
            var items = _context.Items
                .Join(_context.ItemComments,
                item => item.Id,
                comment => comment.Item.Id,
                (item, comment) => new
                {
                    Comment = comment,
                    Item = item
                }
                ).Join(_context.ItemFiles,
                item => item.Item.Id,
                files => files.Item.Id,
                (item, file) => new
                {
                    File = file
                }
                ).ToList();

            return null;
        }

        public IQueryable<ItemEntity> GetPagedItems(Expression<Func<ItemEntity, bool>> filter = null)
        {
            var query = _context.Items
                        .Include(x => x.Project)
                        .Include(x => x.Priority)
                        .Include(x => x.Status)
                        .Include(x => x.Stage)
                        .Include(x => x.Sprint)
                        .Include(x => x.Team)
                        .Include(x => x.AssignedUser);

            if (filter == null)
                return query;

            return query.Where(filter);
        }
    }
}
