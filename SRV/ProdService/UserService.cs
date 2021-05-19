using Entities;
using Repositories;
using SRV.ViewMdel;
using Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProdService
{
    public class UserService : BaseService
    {
        private UserRepository userRepository;
        public UserService()
        {
            //SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
        }
        public int Save(RegisterModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Password = model.Password.MD5Encrypt()
            };
            int userId = userRepository.Save(user);
            return userId;
        }
        public UserModel GetById(int id)
        {
            throw new NotImplementedException("");
        }
        public UserModel GetByName(string name)
        {
            throw new NotImplementedException("");
        }
        public string GetPasswordById(int currentUserId)
        {
            throw new NotImplementedException("");
        }
    }
}
