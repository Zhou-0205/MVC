using Global;
using MVC.Filters;
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
        private ArticleService articleService;
        private SerieService serieService;
        private UserService userService;
        public ArticleController()
        {
            articleService = new ArticleService();
            serieService = new SerieService();
            userService = new UserService();
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
            SingleModel model = articleService.GetSingleById(id);
            return View(model);
        }
        //public ActionResult Appraise(int articleId, Direction direction)
        //{
        //    AppraiseModel model = new AppraiseModel
        //    {
        //        IsAgree = direction
        //    };
        //    articleService.Appraise(articleId, model);
        //    return View();
        //}
        public ActionResult Edit(int id)
        {
            EditModel model = articleService.GetEditById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id, EditModel model)
        {
            articleService.Edit(id, model);
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult SerieList()
        {
            NewModel model = new NewModel
            {
                Author = new UserModel
                {
                    Series = serieService.GetByCurrentUser()
                }
            };
            return PartialView(model);
        }
        public PartialViewResult Serie()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Serie(string serieName)
        {
            SerieModel model = new SerieModel
            {
                Name = serieName
            };
            serieService.Save(model);

            return PartialView();
        }
    }
}