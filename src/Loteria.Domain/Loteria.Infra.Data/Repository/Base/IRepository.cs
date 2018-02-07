using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Loteria.Infra.Data.Base
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IList<TEntity> GetAll();
        IList<TEntity> GetByFilter(Func<TEntity, bool> filter);
        TEntity Insert(TEntity entity);
        bool Delete(int id);
    }
}
