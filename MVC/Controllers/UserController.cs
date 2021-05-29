using MVC.Filters;
using ProdService;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private UserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        [NeedLogOn]
        public ActionResult Info(int id)
        {
            UserInfoModel model = userService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Info(int id, UserInfoModel model, HttpPostedFileBase icon)
        {
            //if (icon.ContentLength > 1024 * 800)
            //{
            //    ModelState.AddModelError("", "");
            //    return View();
            //}
            //if (icon.FileName != "Image/")
            //{
            //    ModelState.AddModelError("", "");
            //    return View();
            //}
            DateTime now = DateTime.Now;
            string urlPath = $"\\Images\\{now.Year}\\{now.Month}\\{now.Day}";
            string extension = Path.GetExtension(icon.FileName);
            string urlName = $"{urlPath}\\{Guid.NewGuid()}{extension}";
            string filePath = Server.MapPath(urlPath);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            
            icon.SaveAs(Server.MapPath(urlName));

            model.IconPath = urlName;
            userService.Edit(id, model);
            return View(model);
        }
    }
}