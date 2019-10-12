using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    class NewsTopics
    {
        public string Label { get; set; }
        public string PicturePath { get; set; }
        public bool IsChecked { get; set; }
        public int TopicId { get; set; }
        public NewsTopics()
        {
            this.IsChecked = false;
        }
    }
}
