using BugCatcher.DataAccessLayer;
using BugCatcher.DataAccessLayer.Abstract;
using BugCatcher.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BugCatcher.BusinessLayer.Managers
{
    public class EfGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : EntityBase, new()
    {
        public DatabaseContext _context;

        public EfGenericRepository() => _context = new DatabaseContext();

        public int Add(TEntity entity)
        {
            using (_context)
            {
                entity.CreDate = DateTime.Now;
                entity.IsActive = true;
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                var id = _context.SaveChanges();

                return id;
            }
        }

        public void Delete(TEntity entity)
        {
            using (_context)
            {
                entity.IsActive = false;
                entity.ModDate = DateTime.Now;
                var deleEnt = _context.Entry(entity);
                deleEnt.State = EntityState.Modified;

                _context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (_context)
            {
                entity.ModDate = DateTime.Now;
                var updatedEntity = _context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (_context)
            {
                return _context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (_context)
            {
                if (filter == null)
                    return _context.Set<TEntity>().ToList();

                return _context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public List<SelectListItem> GetSelectListItems(string text, string value, string defaultValue, int? selectedValue=null, Expression<Func<TEntity, bool>> filter = null)
        {
            using (_context)
            {
                List<SelectListItem> selectListItems = new List<SelectListItem>();

                if (filter == null)
                {
                    var entity = _context.Set<TEntity>();

                    selectListItems = entity.Select(x => new SelectListItem
                    {
                        Text = x.GetType().GetProperty(text).GetValue(x).ToString(),
                        Value = x.GetType().GetProperty(value).GetValue(x).ToString(),
                        Selected = x.Id == selectedValue
                    }).ToList();
                }
                else
                    selectListItems = _context.Set<TEntity>().Where(filter).Select(x => new SelectListItem
                    {
                        Text = x.GetType().GetProperty(text).GetValue(x).ToString(),
                        Value = x.GetType().GetProperty(value).GetValue(x).ToString(),
                        Selected = x.Id == selectedValue
                    }).ToList();

                if (defaultValue != null && defaultValue != "")
                    selectListItems.Insert(0, new SelectListItem { Text = defaultValue, Value = "0", Selected = true, Disabled = true });

                return selectListItems;
            }
        }
    }
}
