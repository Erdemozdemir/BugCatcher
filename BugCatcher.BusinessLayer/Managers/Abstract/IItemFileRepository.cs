using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using System.Collections.Generic;

namespace BugCatcher.BusinessLayer.Managers.Abstract
{
    public interface IItemFileRepository:IGenericRepository<ItemFileEntity>
    {
        List<ItemFileEntity> GetActiveItemFiles(int id); 
        ItemFileEntity GetItemFileIncludeItem(int id); 
    }
}
