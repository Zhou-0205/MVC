using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public User InvitedBy { get; set; }
        public int InviteCode { get; set; }
        public bool? IsMale { get; set; }
        public string IconPath { get; set; }
        public int BirthMonth { get; set; }
        public ConstelKind Constellation { get; set; }
    }
    public enum ConstelKind
    {
        Aries,//白羊
        Taurus,//金牛
        Gemini,//双子
        Cancer,//巨蟹
        Leo,//狮子
        Virgo,//处女
        Libra,//天秤
        scorpio,//天蝎
        sagittarius,//射手
        Capricorn,//摩羯
        Aquarius,//水瓶
        Pisces,//双鱼
    }
}
