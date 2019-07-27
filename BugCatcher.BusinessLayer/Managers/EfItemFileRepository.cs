using System.Collections.Generic;
using System.Linq;
using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfItemFileRepository : EfGenericRepository<ItemFileEntity>, IItemFileRepository
    {
        public List<ItemFileEntity> GetActiveItemFiles(int itemId)
        {
            var list = GetList(x => x.Item.Id == itemId).Where(x=>x.IsActive==true).OrderBy(x => x.CreDate);
            return list.ToList();
        }

        public ItemFileEntity GetItemFileIncludeItem(int id)
        {
            var file = _context.ItemFiles
                        .Include(x=>x.Item)
                        .FirstOrDefault(x=>x.Id==id);
            return file;
        }
    }
}
