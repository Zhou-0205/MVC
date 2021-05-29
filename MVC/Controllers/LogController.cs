using ProdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SRV.ViewModel;
using Global;
using MVC.Filters;

namespace MVC.Controllers
{
    public class LogController : Controller
    {
        private UserService userService;
        public LogController()
        {
            userService = new UserService();
        }
        [ModelErrorTransferFilter]
        public ActionResult On()
        {
            return View();
        }
        [HttpPost]
        [ModelErrorTransferFilter]
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
                ModelState.AddModelError("Password", "* 用户名或密码错误");
                return View();
            }
            //if (Session[Keys.Captcha].ToString() != model.Captcha)
            //{
            //    ModelState.AddModelError("Captcha", "* 验证码错误");
            //    return View();
            //}
            int userId = user.Id;
            string name = user.Name;
            string passWord = user.Password;

            HttpCookie cookie = new HttpCookie(Keys.User);
            cookie.Values.Add(Keys.Id, userId.ToString());
            cookie.Values.Add(Keys.Name, Server.UrlEncode(name));
            cookie.Values.Add(Keys.PassWord, passWord.ToString());
            Response.Cookies.Add(cookie);

            string path = Request.QueryString["prepage"]?.ToString();
            if (!string.IsNullOrEmpty(path))
            {
                return Redirect(path);
            }
            return View();
        }
        public ActionResult Off()
        {
            HttpCookie cookie = HttpContext.Request.Cookies[Keys.User];
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            string path = Request.Headers["referer"];
            return Redirect(path);
        }
    }
}