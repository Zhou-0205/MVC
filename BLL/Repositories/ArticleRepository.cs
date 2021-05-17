using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ArticleRepository : BaseRepository<Article>
    {
        public ArticleRepository()
        {
            context = new SqlDbContext<Article>();
        }
        public Article GetById(int id)
        {
            return context.Entities
                .Where(a => a.Id == id)
                .SingleOrDefault();
        }
    }
}
