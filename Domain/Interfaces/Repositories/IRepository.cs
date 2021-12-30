using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        void AddRange(IEnumerable<TEntity> entities);

        void UpdateRange(IEnumerable<TEntity> entities);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Add(TEntity obj);

        IQueryable<TEntity> GetAll();

        TEntity GetById(object id);

        void Remove(object id);

        void Remove(TEntity entities);

        void Update(TEntity obj);
    }
}