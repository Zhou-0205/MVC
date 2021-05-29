using Global;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class SharedController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult _User()
        {
            return PartialView();
        }
        public FileContentResult _Captcha()
        {
            MemoryStream stream = new MemoryStream();
            string CaptchStr = Helpers.Captcha.GenerateString();
            Session[Keys.Captcha] = CaptchStr;
            Helpers.Captcha.GenerateBitmap(CaptchStr).Save(stream, ImageFormat.Jpeg);
            return File(stream.ToArray(), "image/png");
        }
    }
}