using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;

namespace BugCatcher.BusinessLayer.Managers.Abstract
{
    public interface IQueryRepository : IGenericRepository<QueryEntity>
    {
    }
}
