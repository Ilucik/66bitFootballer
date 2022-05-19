using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EFFootballerRepository : IRepository<Footballer>
    {
        private readonly EFDBContext context;

        public EFFootballerRepository(EFDBContext context)
        {
            this.context = context;
        }

        public int Add(Footballer entity)
        {
            var e = context.Footballer.Add(entity);
            context.SaveChanges();
            return e.Entity.Id;
        }

        public IEnumerable<Footballer> Get(Func<Footballer, bool> selector)
        {
            return context.Footballer.Include(f=>f.Team).Where(selector);
        }

        public IEnumerable<Footballer> GetAll()
        {
            return context.Footballer.Include(f => f.Team).ToList();
        }

        public Footballer GetById(int id)
        {
            return context.Footballer.Include(f => f.Team).FirstOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            context.Footballer.Remove(GetById(id));
            context.SaveChanges();
        }

        public void Update(Footballer entity)
        {
            context.Footballer.Update(entity);
            context.SaveChanges();
        }
    }
}
