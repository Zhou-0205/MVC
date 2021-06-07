using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Serie : BaseEntity
    {
        public string Name { get; set; }
        public IList<Article> Articles { get; set; }
        public int? AuthorId { get; set; }
        public User Author { get; set; }
    }
}
