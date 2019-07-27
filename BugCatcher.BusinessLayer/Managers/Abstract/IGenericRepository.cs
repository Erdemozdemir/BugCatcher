using BugCatcher.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BugCatcher.DataAccessLayer.Abstract
{
    public interface IGenericRepository<T> where T: EntityBase, new()
    {
        T Get(Expression<Func<T, bool>> filter=null);

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
