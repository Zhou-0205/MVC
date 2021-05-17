using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        protected SqlDbContext<T> context;
        public BaseRepository()
        {

        }
        public int Save(T entity)
        {
            context.Entities.Add(entity);
            context.SaveChanges();
            return entity.Id;
        }
        public void Remove(T entity)
        {

        }
    }
}
