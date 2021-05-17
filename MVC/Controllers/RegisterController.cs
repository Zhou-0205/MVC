using Entities;
using MVC.Filters;
using MVC.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        private UserRepository userRepository;
        public RegisterController()
        {
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (userRepository.GetByName(model.Name) != null)
            {
                ModelState.AddModelError("Name", "* 用户名不能重复");
                return RedirectToAction(nameof(Register));
            }
            User user = new User
            {
                Name = model.Name,
                Password = model.Password
            };
            int id = userRepository.Save(user);

            return View();
        }
    }
}