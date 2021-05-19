using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ViewMdel;
using Global;

namespace MVC.Controllers
{
    public class LogController : Controller
    {
        private UserService userService;
        public LogController()
        {
            userService = new UserService();
        }
        public ActionResult On()
        {
            return View();
        }
        [HttpPost]
        public ActionResult On(LogOnModel model)
        {
            UserModel user = userService.GetByName(model.Name);
            if (user == null)
            {
                ModelState.AddModelError("Name", "* 用户不存在");
                return View();
            }
            if (user.Password != model.Password.MD5Encrypt())
            {
                ModelState.AddModelError("Password","* 密码错误");
                return View();
            }
            int userId = user.Id;
            string passWord = user.Password;

            HttpCookie cookie = new HttpCookie(Keys.User);
            cookie.Values.Add(Keys.Id, userId.ToString());
            cookie.Values.Add(Keys.PassWord, passWord.ToString().MD5Encrypt());
            Response.Cookies.Add(cookie);

            return View();
        }
    }
}