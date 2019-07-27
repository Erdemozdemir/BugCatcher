using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using System.Collections.Generic;

namespace BugCatcher.BusinessLayer.Managers.Abstract
{
    interface IProjectSubscriberRepository : IGenericRepository<ProjectSubscribersEntity>
    {
        IEnumerable<UserEntity> GetProjectSubscribersOrNull(int projectId);
    }
}
