using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CovidOut.Repositories {
    public interface IGenericRepository<TEntity> {
        public TEntity Find(Guid id);
        public IEnumerable<TEntity> GetAll();
        
        public IEnumerable<TEntity> Query (Expression<Func<TEntity, bool>> predicate); 

        public Guid Add(TEntity entity);
        public Guid Update(TEntity entity);
        public Guid Delete(TEntity entity);

    }
}