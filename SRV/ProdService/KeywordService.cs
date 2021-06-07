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
    public class KeywordService : BaseService
    {
        private KeywordRepository keywordRepository;
        public KeywordService()
        {
            keywordRepository = new KeywordRepository(context);
        }
        public int Save(KeywordModel model)
        {
            Keyword keyword = new Keyword
            {
                Name = model.Name
            };
            keywordRepository.Save(keyword);
            return keyword.Id;
        }
    }
}
