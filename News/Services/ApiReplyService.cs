using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services
{
    public class ApiReplyService
    {
        public static List<Article> SaveNewsSourcesList { get; set; } = new List<Article>();
        //новости из раздела источники
        public static List<Article> SaveNewsMainPageList { get; set; } = new List<Article>();
        //новости на главной странице
    }
}
