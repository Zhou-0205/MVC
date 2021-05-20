using Global;
using MVC.Filters;
using ProdService;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        UserService userService;
        public RegisterController()
        {
            userService = new ProdService.UserService();
        }

        [ModelErrorTransferFilter]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ModelErrorTransferFilter]
        public ActionResult Register(RegisterModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
            //if (userService.GetByName(model.Name) != null)
            //{
            //    ModelState.AddModelError("Name", "* 用户名不能重复");
            //    return RedirectToAction(nameof(Register));
            //}
            int userId = userService.Save(model);

            //HttpCookie cookie = new HttpCookie(Keys.User);
            //cookie.Values.Add(Keys.Id, userId.ToString());
            //cookie.Values.Add(Keys.PassWord,model.Password.ToString().MD5Encrypt());
            //Response.Cookies.Add(cookie);

            return View();
        }
    }
}