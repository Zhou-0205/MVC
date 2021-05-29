using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ViewModel
{
    public class UserInfoModel
    {
        public bool? IsMale { get; set; }
        public string IconPath { get; set; }
        public int BirthMonth { get; set; }
        public ConstelKind Constellation { get; set; }
    }
    public enum ConstelKind
    {
        [Display(Name = "白羊座")]
        Aries,
        [Display(Name = "金牛座")]
        Taurus,
        [Display(Name = "双子座")]
        Gemini,
        [Display(Name = "巨蟹座")]
        Cancer,
        [Display(Name = "狮子座")]
        Leo,
        [Display(Name = "处女座")]
        Virgo,
        [Display(Name = "天秤座")]
        Libra,
        [Display(Name = "天蝎座")]
        scorpio,
        [Display(Name = "射手座")]
        sagittarius,
        [Display(Name = "摩羯座")]
        Capricorn,
        [Display(Name = "水瓶座")]
        Aquarius,
        [Display(Name = "双鱼座")]
        Pisces,
    }
}
