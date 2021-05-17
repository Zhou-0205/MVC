using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository()
        {
            context = new SqlDbContext<User>();
        }
        public User Find(int id)
        {
            return context.Entities.Where(u => u.Id == id).SingleOrDefault();
        }
        public User GetByName(string name)
        {
            return context.Entities
                .Where(u => u.Name == name)
                .SingleOrDefault();
        }
    }
}
