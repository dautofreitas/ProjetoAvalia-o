using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Repository.RepositoryInterfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Dispose();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindSingle(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int? id);
        void Remove(TEntity obj);
        void Update(TEntity obj);
    }
}