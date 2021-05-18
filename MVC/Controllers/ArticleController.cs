using ProdService;
using SRV.ViewMdel;
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
            articleService.Publish(model,1);
            return View();
        }
    }
}