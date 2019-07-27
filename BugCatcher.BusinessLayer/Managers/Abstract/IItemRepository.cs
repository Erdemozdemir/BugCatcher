using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BugCatcher.BusinessLayer.Managers.Abstract
{
    public interface IItemRepository:IGenericRepository<ItemEntity>
    {
        List<ItemEntity> GetItemsByUser(Expression<Func<ItemEntity,bool>> filter=null);
        List<ItemEntity> GetIncludedItems(Expression<Func<ItemEntity,bool>> filter=null);

        List<ItemEntity> GetItemsCommentsAndFiles(int id);
        IQueryable<ItemEntity> GetPagedItems(Expression<Func<ItemEntity, bool>> filter = null);
    }
}
