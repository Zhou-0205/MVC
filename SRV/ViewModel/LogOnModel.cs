﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewMdel
{
    public class LogOnModel
    {
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "* 用户名不能为空")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* 密码不能为空")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "* 确认密码不能为空")]
        //public string ConfirmPassWord { get; set; }
    }
}
