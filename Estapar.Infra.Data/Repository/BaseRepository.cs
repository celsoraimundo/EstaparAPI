using Estapar.Domain.Entities;
using Estapar.Domain.Interfaces;
using Estapar.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Estapar.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private essenceestaparContext context;

        public BaseRepository(essenceestaparContext context)
        {
            this.context = context;
        }

        public void Insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void Update(T obj)
        {
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Select(id));
            context.SaveChanges();
        }

        public IList<T> Select()
        {
            return context.Set<T>().ToList();
        }

        public T Select(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}