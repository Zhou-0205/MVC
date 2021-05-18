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
    public class ArticleService
    {
        private UserRepository userRepository;
        private ArticleRepository articleRepository;
        public ArticleService()
        {
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
            articleRepository = new ArticleRepository(context);
        }
        public int Publish(NewModel model,int currrentId)
        {
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body
            };
            User author = userRepository.Load(currrentId);
            article.Author = author;
            return article.Id;
        }
    }
}
