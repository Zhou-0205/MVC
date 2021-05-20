using MVC.Helpers;
using ProdService;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ArticleController : Controller
    {
        ArticleService articleService;
        public ArticleController()
        {
            articleService = new ArticleService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(NewModel model)
        {
            articleService.Publish(model);
            return View();
        }
        public ActionResult Single(int id)
        {
            SingleModel model = articleService.GetById(id);
            return View(model);
        }
    }
}