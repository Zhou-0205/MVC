using Entities;
using Repositories;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdService
{
    public class SerieService : BaseService
    {
        private SerieRepository serieRepository;
        public SerieService()
        {
            serieRepository = new SerieRepository(context);
        }
        public IList<SerieModel> GetByCurrentUser()
        {
            User user = GetCurrentUser(false);
            IList<Serie> series = serieRepository.GetByUserId(user.Id).ToList();
            IList<SerieModel> models = new List<SerieModel>();
            foreach (var item in series)
            {
                models.Add(new SerieModel { Id = item.Id, Name = item.Name });
            }
            return models;
        }
        public int Save(SerieModel model)
        {
            Serie serie = new Serie
            {
                Name = model.Name,
                Author = GetCurrentUser(false)
            };
            serieRepository.Save(serie);
            return serie.Id;
        }
    }
}
