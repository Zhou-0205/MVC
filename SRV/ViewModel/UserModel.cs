using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "* 邀请人不能为空")]
        public string Name { get; set; }
        public string Password { get; set; }
        public UserModel InvitedBy { get; set; }

        [Required(ErrorMessage = "* 邀请码不能为空")]
        public int InviteCode { get; set; }
        public IList<SerieModel> Series { get; set; }
    }
}
