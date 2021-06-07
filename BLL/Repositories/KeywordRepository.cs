using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class KeywordRepository : BaseRepository<Keyword>
    {
        public KeywordRepository(SqlDbContext context) : base(context)
        {

        }
        public IList<string> splitKeywords(string keywords)
        {
            IList<string> ListKeywords = new List<string>();
            string substr;
            int blankIndex = 0;
            for (int i = 0; i < keywords.Length; i++)
            {
                if (i == keywords.Length - 1)
                {
                    substr = keywords.Substring(blankIndex, i - blankIndex + 1).Trim();
                    ListKeywords.Add(substr);
                }
                else if (keywords[i] == ' ')
                {
                    substr = keywords.Substring(blankIndex, i - blankIndex + 1).Trim();
                    ListKeywords.Add(substr);
                    blankIndex = i + 1;
                }//else nothing
            }
            return ListKeywords;
        }
        public Keyword GetByName(string name)
        {
            return Dbset
                .Where(k => k.Name == name)
                .SingleOrDefault();
        }
    }
}
