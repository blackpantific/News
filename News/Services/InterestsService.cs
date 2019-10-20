using News.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Services
{
    public class InterestsService
    {
        public static List<NewsTopics> SaveSelectedListBoxItems { get;  set; } = new List<NewsTopics>();
        
    }
}
