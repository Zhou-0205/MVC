using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class SerieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserModel User { get; set; }
    }
}
