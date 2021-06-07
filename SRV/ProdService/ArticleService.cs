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
        private ArticleRepository articleRepository;
        private SerieRepository serieRepository;
        private KeywordRepository keywordRepository;
        private UserRepository userRepository;
        public ArticleService()
        {
            articleRepository = new ArticleRepository(context);
            serieRepository = new SerieRepository(context);
            keywordRepository = new KeywordRepository(context);
            userRepository = new UserRepository(context);
        }
        public int Publish(NewModel model)
        {
            Article article = new Article
            {
                Title = model.Title,
                Body = model.Body,
                Author = GetCurrentUser(false),
                Digest = model.Digest
            };
            article.Belong = serieRepository.Find(model.Belong.Id);

            IList<string> strKeywords = keywordRepository.splitKeywords(model.Keywords);
            IList<Keyword> objKeywords = new List<Keyword>();
            Keyword keyword;
            foreach (var item in strKeywords)
            {
                if (keywordRepository.GetByName(item) == null)
                {
                    Keyword newKeyword = new Keyword
                    {
                        Name = item
                    };
                    keywordRepository.Save(newKeyword);
                    keyword = newKeyword;
                }
                else
                {
                    keyword = keywordRepository.GetByName(item);
                }
                objKeywords.Add(keyword);
            }

            article.Keywords = objKeywords;

            articleRepository.Save(article);
            return article.Id;
        }

        //public void Appraise(int articleId, AppraiseModel model)
        //{
        //    Article article = articleRepository.Find(articleId);
        //    article.Appraise = new Appraise
        //    {
        //        IsAgree = model.IsAgree,
        //        Voter = GetCurrentUser()
        //    };
        //    article.Agree(article.Appraise.Voter);
        //    articleRepository.Save(article);
        //}
        public void Edit(int id, EditModel model)
        {
            Article article = articleRepository.Find(id);
            mapper.Map<EditModel, Article>(model, article);

            articleRepository.Edit();
        }
        public EditModel GetEditById(int id)
        {
            Article article = articleRepository.Find(id);
            EditModel model = mapper.Map<EditModel>(article);

            return model;
        }
        public SingleModel GetSingleById(int id)
        {
            Article article = articleRepository.Find(id);
            //SingleModel model = mapper.Map<SingleModel>(article);
            User user = userRepository.GetById(article.AuthorId);
            SingleModel model = new SingleModel
            {
                Id = article.Id,
                Title = article.Title,
                Body = article.Body,
                Author = new UserModel
                {
                    Id = user.Id,
                    Name = user.Name
                }
            };

            return model;
        }
    }
}
