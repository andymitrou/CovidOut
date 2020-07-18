using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CovidOut.Data;

namespace CovidOut.Repositories {
    public abstract class GenericRepository<T> : IGenericRepository<T>
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(){}
        public Guid Add(T entity)
        {
        
            throw new NotImplementedException();
        }

        public Guid Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Guid Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}