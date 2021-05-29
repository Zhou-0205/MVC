using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class LogOnModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "* 用户名不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* 密码不能为空")]
        public string Password { get; set; }

        [Required(ErrorMessage = "* 验证码不能为空")]
        public string Captcha { get; set; }
    }
}
