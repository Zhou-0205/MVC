using AutoMapper;
using Entities;
using Global;
using Repositories;
using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProdService
{
    public class BaseService
    {
        private UserRepository userRepository;
        protected readonly static MapperConfiguration config;
        static BaseService()
        {
            config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Article, SingleModel>().ReverseMap();
                    cfg.CreateMap<Article, EditModel>().ReverseMap();
                    cfg.CreateMap<Article, NewModel>().ReverseMap();
                    cfg.CreateMap<User, UserModel>().ReverseMap();
                    cfg.CreateMap<User, UserInfoModel>().ReverseMap();
                }
                );
        }
        public BaseService()
        {
            userRepository = new UserRepository(context);
        }
        protected IMapper mapper
        {
            get { return config.CreateMapper(); }
        }
        protected SqlDbContext context
        {
            get
            {
                if (HttpContext.Current.Items[Keys.DbContext] == null)
                {
                    SqlDbContext dbContext = new SqlDbContext();
                    dbContext.Database.BeginTransaction();
                    HttpContext.Current.Items[Keys.DbContext] = dbContext;
                }//else nothing
                return (SqlDbContext)HttpContext.Current.Items[Keys.DbContext];
            }
        }

        private static SqlDbContext GetContextFromHttp()
        {
            object objContext = HttpContext.Current.Items[Keys.DbContext];
            return objContext as SqlDbContext;
        }

        public static void Commit()
        {
            SqlDbContext context = GetContextFromHttp();
            if (context != null)
            {
                using (context)
                {
                    using (DbContextTransaction transaction = context.Database.CurrentTransaction)
                    {
                        transaction.Commit();
                    }
                }
            }//else nothing
        }

        public static void RollBack()
        {
            SqlDbContext context = GetContextFromHttp();
            if (context != null)
            {
                using (context)
                {
                    using (DbContextTransaction transaction = context.Database.CurrentTransaction)
                    {
                        transaction.Rollback();
                    }
                }
            }//else nothing
        }

        protected User GetCurrentUser(bool userProxy = true)
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

            User currentUser = userProxy ?
                userRepository.Load(currentUserId) :
                userRepository.Find(currentUserId);

            if (currentUser.Password != pwdInCookie)
            {
                throw new ArgumentException("");
            }

            return currentUser;
        }
    }
}
