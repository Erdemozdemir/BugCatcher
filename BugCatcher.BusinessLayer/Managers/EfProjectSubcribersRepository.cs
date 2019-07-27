using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfProjectSubcribersRepository : EfGenericRepository<ProjectSubscribersEntity>, IProjectSubscriberRepository
    {
        public IEnumerable<UserEntity> GetProjectSubscribersOrNull(int projectId)
        {
            var subscribers = _context.ProjectSubscribers
                .Include(u => u.User)
                .Include(p => p.Project)
                .Where(x => x.Project.Id == projectId).Select(x => x.User); 
                
            if (subscribers != null)
                return subscribers;

            return null;
        }
    }
}
