using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepository<T> where T : BaseEntity, new()
    {
        protected SqlDbContext context;
        protected DbSet<T> Dbset;
        public BaseRepository(SqlDbContext context)
        {
            this.context = context;
            Dbset = context.Set<T>();
        }
        public int Save(T entity)
        {
            Dbset.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }
        public void Edit()
        {
            context.SaveChanges();
        }
        public T Find(int id)
        {
            return Dbset.Find(id);
        }
        public T Load(int id)
        {
            T entity = new T { Id = id };
            Dbset.Attach(entity);
            return entity;
        }
    }
}
