using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IRepository<T> where T : Entity
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public IEnumerable<T> Get(Func<T, bool> selector);
        public int Add(T entity);
        public void Update(T entity);
        public void Remove(int id);

    }
}
