using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfQueryRepository:EfGenericRepository<QueryEntity>,IQueryRepository
    {
    }
}
