using BugCatcher.Entities.Concrete;

namespace BugCatcher.WebApplication.Helpers
{
    public class EntityHelper
    {
        public int CheckEntityBaseAndGetValueOrNull(EntityBase entity)
        {
            if (entity != null && entity.Id > 0)
                return entity.Id;

            return 0;
        }

    }
}
