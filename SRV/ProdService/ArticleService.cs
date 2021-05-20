using AutoMapper;
using Entities;
using Repositories;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdService
{
    public class ArticleService : BaseService
    {
        private UserRepository userRepository;
        private ArticleRepository articleRepository;
        public ArticleService()
        {
            userRepository = new UserRepository(context);
            articleRepository = new ArticleRepository(context);
        }
        public int Publish(NewModel model)
        {
            if (GetCurrentUser() == null)
            {
                throw new ArgumentException("");
            }
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body,
                Author = GetCurrentUser(true)
            };

            articleRepository.Save(article);
            return article.Id;
        }
        public SingleModel GetById(int id)
        {
            Article article = articleRepository.Find(id);

            SingleModel model = mapper.Map<SingleModel>(article);

            return model;

            //return new SingleModel
            //{
            //    Title = article.Title,
            //    Body = article.Body,
            //    Author = article.Author
            //};
        }
    }
}
