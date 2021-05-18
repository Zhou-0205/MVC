
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SRV.ViewMdel
{
    public class NewModel
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
    }
}