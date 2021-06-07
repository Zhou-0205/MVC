using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class EditModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
        public IList<Keyword> Keywords { get; set; }
        public Serie Belong { get; set; }
        public string Digest { get; set; }
    }
}
