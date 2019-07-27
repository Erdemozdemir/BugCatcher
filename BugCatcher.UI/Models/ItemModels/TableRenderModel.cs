using BugCatcher.BusinessLayer.Managers;
using BugCatcher.Entities.Concrete;
using BugCatcher.Entities.CustomDataAnnotation;
using BugCatcher.UI.Models.ItemModels;
using BugCatcher.WebApplication.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCatcher.UI.Models
{
    public class TableRenderModel
    {
        private int count;
        private int pageSize;
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<ItemSelectModel> ItemSelects{ get; set; }
        public IEnumerable<System.Reflection.PropertyInfo> Properties{ get; set; }

        public TableRenderModel()
        {

        }

        public TableRenderModel(IEnumerable<ItemSelectModel> itemSelectModel, IEnumerable<System.Reflection.PropertyInfo> prop, int count, int pageIndex, int pageSize)
        {
            this.count = count;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.pageSize = pageSize;
            this.Properties = prop;
            this.ItemSelects = itemSelectModel;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
        /// <summary>
        /// Returns Paged <code>TableRenderModel</code> object
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static async Task<TableRenderModel> CreateAsync(IQueryable<ItemEntity> source, int pageIndex, int? pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * (int)pageSize).Take((int)pageSize).ToListAsync();

            var properties = typeof(ItemEntity).GetProperties().Where(p => p.GetCustomAttributes(typeof(ShowInFilter), false).Length == 1).Select(p => p);

            var selectModel = items.Select(
                x => new ItemSelectModel
                {
                    Item = x,
                    ProjectSelect = new EfGenericRepository<ProjectEntity>().GetSelectListItems("Name", "Id", "Choose Project", new EntityHelper().CheckEntityBaseAndGetValueOrNull(x.Project)),
                    TeamSelect = new EfGenericRepository<TeamEntity>().GetSelectListItems("Name", "Id", "Choose Team", new EntityHelper().CheckEntityBaseAndGetValueOrNull(x.Team)),
                    PrioritySelect = new EfGenericRepository<PriorityEntity>().GetSelectListItems("Name", "Id", "Choose Priority", new EntityHelper().CheckEntityBaseAndGetValueOrNull(x.Priority)),
                    StageSelect = new EfGenericRepository<StageEntity>().GetSelectListItems("Name", "Id", "Choose Stage", new EntityHelper().CheckEntityBaseAndGetValueOrNull(x.Stage)),
                    StatusSelect = new EfGenericRepository<StatusEntity>().GetSelectListItems("Name", "Id", "Choose Status", new EntityHelper().CheckEntityBaseAndGetValueOrNull(x.Status)),
                    AssignedUserSelect = new EfUserRepository().GetSelectListItems("Choose A User", x.AssignedUser.Id),
                    SprintSelect = new EfGenericRepository<SprintEntity>().GetSelectListItems("Name", "Id", null, new EntityHelper().CheckEntityBaseAndGetValueOrNull(x.Sprint))
                }).ToList();


            return new TableRenderModel(selectModel,properties, count, pageIndex, (int)pageSize );
        }
    }
}
