using Global;
using ProdService;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace MVC.Helpers
{
    public class CookieHelper
    {
        private UserService userService;
        public CookieHelper()
        {
            userService = new ProdService.UserService();
        }
        public static void Delete()
        { }
        //public int? GetCurrentId()
        //{
        //    NameValueCollection userInfo = HttpContext.Current.Request.Cookies[Keys.User].Values;
        //    if (userInfo == null)
        //    {

        //    }

        //    bool hasUserId = int.TryParse(userInfo[Keys.Id], out int currentUserId);
        //    if (!hasUserId)
        //    {
        //        throw new ArgumentException("");
        //    }

        //    string pwdInCookie = userInfo[Keys.PassWord];
        //    if (string.IsNullOrEmpty(pwdInCookie))
        //    {
        //        throw new ArgumentException("");
        //    }

        //    string pwd = userService.GetPasswordById(currentUserId);
        //    if (pwd != pwdInCookie.MD5Encrypt())
        //    {
        //        throw new ArgumentException("");
        //    }

        //    return currentUserId;
        //}
    }
}