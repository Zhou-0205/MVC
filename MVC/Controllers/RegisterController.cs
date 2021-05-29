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
            if (userService.GetByName(model.Name) != null)
            {
                ModelState.AddModelError("Name", "* 用户名重复");
                return View();
            }
            if (userService.GetByName(model.InvitedBy.Name) == null)
            {
                ModelState.AddModelError("InvitedBy.Name", "* 邀请人不存在");
                return View();
            }
            if (model.InvitedBy.InviteCode != userService.GetByName(model.InvitedBy.Name).InviteCode)
            {
                ModelState.AddModelError("InvitedBy.InviteCode", "* 邀请人或邀请码错误");
                return View();
            }

            userService.Save(model);

            return RedirectToAction("On","Log");
        }
    }
}