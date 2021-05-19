using Entities;
using Repositories;
using SRV.ViewMdel;
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
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
            articleRepository = new ArticleRepository(context);
        }
        public int Publish(NewModel model/*, int currrentId*/)
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
            //User author = userRepository.Load(currrentId);
            //article.Author = author;
            articleRepository.Save(article);
            return article.Id;
        }
    }
}
