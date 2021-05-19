using Entities;
using Global;
using Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProdService
{
    public class BaseService
    {
        private UserRepository userRepository;
        public BaseService()
        {
            SqlDbContext context = new SqlDbContext();
            userRepository = new UserRepository(context);
        }

        public User GetCurrentUser(bool userPoxy = true)
        {
            NameValueCollection userInfo =
                HttpContext.Current.Request.Cookies[Keys.User].Values;
            if (userInfo == null)
            {
                return null;
            }

            bool hasUserId = int.TryParse(userInfo[Keys.Id], out int currentUserId);
            if (!hasUserId)
            {
                throw new ArgumentException("");
            }

            string pwdInCookie = userInfo[Keys.PassWord];
            if (string.IsNullOrEmpty(pwdInCookie))
            {
                throw new ArgumentException("");
            }

            User currentUser = userPoxy ?
                userRepository.Load(currentUserId) :
                userRepository.Find(currentUserId);

            if (currentUser.Password != pwdInCookie.MD5Encrypt())
            {
                throw new ArgumentException("");
            }

            return currentUser;
        }
    }
}
