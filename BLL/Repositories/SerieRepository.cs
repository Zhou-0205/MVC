using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class SerieRepository : BaseRepository<Serie>
    {
        public SerieRepository(SqlDbContext context) : base(context)
        {

        }
        public Serie GetByName(string name)
        {
            return Dbset
                .Where(s => s.Name == name)
                .SingleOrDefault();
        }
        public IQueryable<Serie> GetByUserId(int userId)
        {
            return Dbset.Where(s => s.AuthorId == userId);
        }
    }
}
