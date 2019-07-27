using BugCatcher.BusinessLayer.Managers;
using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace BugCatcher.WebApplication.Helpers
{
    public class ProjectHelper
    {
        private readonly EfGenericRepository<ProjectEntity> _repositoryBase;
        public ProjectHelper()
        {
            _repositoryBase = new EfGenericRepository<ProjectEntity>();
        }

        public List<SelectListItem> GetSelectListItems()
        {
            var List=_repositoryBase.GetList();


            return List.Select(
                x=>
                new SelectListItem
                {
                    Text =x.Name,
                    Value =x.Id.ToString()
                }).ToList();
        }
    }
}
