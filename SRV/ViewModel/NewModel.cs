
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SRV.ViewModel
{
    public class NewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public UserModel Author { get; set; }
        public string Keywords { get; set; }
        public SerieModel Belong { get; set; }
        public string Digest { get; set; }
    }
}