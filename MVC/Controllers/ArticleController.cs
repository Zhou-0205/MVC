using Entities;
using MVC.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ArticleController : Controller
    {
        private UserRepository userRepository;
        private ArticleRepository articleRepository;
        public ArticleController()
        {
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
            articleRepository = new ArticleRepository(context);
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
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body
            };
            User author = userRepository.Load(1);
            article.Author = author;
            articleRepository.Save(article);
            return View();
        }
    }
}