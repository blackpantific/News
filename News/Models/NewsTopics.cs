using News.Helpers;
using News.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models
{
    public class NewsTopics : BindableBase
    {
        private bool _isChecked;
        public string Label { get; set; }
        public string PicturePath { get; set; }
        public bool IsChecked
        {
            get
            {
                return _isChecked;             
            }
          set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");

                if (value)
                {
                    if (!InterestsService.SaveSelectedListBoxItems.Any(item => item.TopicId == this.TopicId))
                    {
                        InterestsService.SaveSelectedListBoxItems.Add(this);
                    }
                }
                else
                {
                    InterestsService.SaveSelectedListBoxItems.Remove(InterestsService.SaveSelectedListBoxItems
                        .FirstOrDefault(item => item.TopicId == this.TopicId));
                }       
            }
        }
        public int TopicId { get; set; }
        public NewsTopics()
        {
            this.IsChecked = false;
        }
    }
}
