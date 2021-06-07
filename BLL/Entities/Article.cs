using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Article : BaseEntity
    {
        public int? AuthorId { get; set; }
        public User Author { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public IList<Keyword> Keywords { get; set; }
        public Serie Belong { get; set; }
        public string Digest { get; set; }
        public IList<Comment> Comments { get; set; }
        public Appraise Appraise { get; set; }
        public int AgreeCount { get; set; }
        public int DisAgreeCount { get; set; }

        public void Agree(User voter)
        {
            AgreeCount++;
        }
        public void Disagree(User voter)
        {
            DisAgreeCount++;
        }
    }
}
