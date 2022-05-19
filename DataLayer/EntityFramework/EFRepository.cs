using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EFRepository<T> : IRepository<T>
        where T : Entity
    {
        private readonly EFDBContext context;

        public EFRepository(EFDBContext context)
        {
            this.context = context;
        }

        public int Add(T entity)
        {
            var e = context.Set<T>().Add(entity);
            context.SaveChanges();
            return e.Entity.Id;
        }

        public IEnumerable<T> Get(Func<T, bool> selector)
        {
            return context.Set<T>().Where(selector);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return context.Set<T>().FirstOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            context.Set<T>().Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}
