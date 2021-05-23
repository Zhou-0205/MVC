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
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body,
                Author = GetCurrentUser(false)
            };
            articleRepository.Save(article);
            return article.Id;
        }
        public void Edit(int id, EditModel model)
        {
            Article article = articleRepository.Find(id);
            mapper.Map<EditModel, Article>(model, article);

            articleRepository.Edit();
        }

        public EditModel GetEdit(int id)
        {
            Article article = articleRepository.Find(id);
            EditModel model = mapper.Map<EditModel>(article);

            return model;
        }

        public SingleModel GetById(int id)
        {
            Article article = articleRepository.Find(id);
            SingleModel model = mapper.Map<SingleModel>(article);

            return model;
        }
    }
}
