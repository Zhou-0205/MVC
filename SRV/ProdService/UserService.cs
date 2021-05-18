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
    public class UserService
    {
        private UserRepository userRepository;
        public UserService()
        {
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
        }
        public int Save(RegisterModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Password = model.Password
            };
            return user.Id;
        }

        public RegisterModel GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
