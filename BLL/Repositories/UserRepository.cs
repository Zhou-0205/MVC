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
        public UserRepository(SqlDbContext context) : base(context)
        {
        }
        public User Find(int id)
        {
            return Dbset.Find(id);
        }
        public User GetByName(string name)
        {
            return Dbset
                .Where(u => u.Name == name)
                .SingleOrDefault();
        }
    }
}
