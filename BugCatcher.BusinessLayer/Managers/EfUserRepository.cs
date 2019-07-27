using BugCatcher.BusinessLayer.Managers.Abstract;
using BugCatcher.DataAccessLayer;
using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfUserRepository : IUserRepository
    {
        private DatabaseContext _context;
        public EfUserRepository()
        {
            _context = new DatabaseContext();
        }

        public List<UserEntity> GetUsers()
        {
            return _context.Users.ToList();
        }

        public List<SelectListItem> GetSelectListItems(string defaultValue, string selectedValue = null, Expression<Func<UserEntity, bool>> filter = null)
        {
            using (_context)
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();

                if (filter == null)
                {
                    var entity = _context.Set<UserEntity>();

                    selectListItems = entity.Select(x => new SelectListItem
                    {
                        Text = x.UserName,
                        Value = x.Id,
                        Selected = x.Id == selectedValue
                    }).ToList();
                }
                else
                    selectListItems = _context.Set<UserEntity>().Where(filter).Select(x => new SelectListItem
                    {
                        Text = x.UserName,
                        Value = x.Id,
                        Selected = x.Id == selectedValue
                    }).ToList();

                if (defaultValue != null && defaultValue != "")
                    selectListItems.Insert(0, new SelectListItem { Text = defaultValue, Value = "0", Selected = true, Disabled = true });

                return selectListItems;
            }
        }
    }
}
