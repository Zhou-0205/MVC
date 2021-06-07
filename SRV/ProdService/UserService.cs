using Entities;
using Repositories;
using SRV.ViewModel;
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
            userRepository = new UserRepository(context);
        }

        public UserInfoModel GetById(int id)
        {
            User user = userRepository.Find(id);
            UserInfoModel model = mapper.Map<UserInfoModel>(user);
            return model;
        }
        public UserModel GetByCurrent()
        {
            User user = GetCurrentUser();
            UserModel model = new UserModel
            {
                Id=user.Id,
                Name=user.Name
            };
            return model;
        }

        public void Edit(int id, UserInfoModel model)
        {
            User user = userRepository.Find(id);
            mapper.Map<UserInfoModel, User>(model, user);

            userRepository.Edit();
        }

        public int Save(RegisterModel model)
        {
            User user = new User
            {
                Name = model.Name,
                Password = model.Password.MD5Encrypt(),
                InvitedBy = userRepository.GetByName(model.InvitedBy.Name)
            };
            userRepository.Save(user);
            return user.Id;
        }
        public UserModel GetByName(string name)
        {
            User user = userRepository.GetByName(name);
            UserModel model = mapper.Map<UserModel>(user);
            return model;
        }
    }
}
