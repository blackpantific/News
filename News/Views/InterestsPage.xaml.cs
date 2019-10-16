using News.Helpers;
using News.Models;
using News.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace News
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class InterestsPage : Page, INotifyPropertyChanged
    {
        

        private ObservableCollection<NewsTopics> listOfCurrentNewsTopics;
        public ObservableCollection<NewsTopics> ListOfCurrentNewsTopics
        {
            get { return listOfCurrentNewsTopics; }
            set
            {
                if (listOfCurrentNewsTopics != value)
                {
                    listOfCurrentNewsTopics = value;
                    OnPropertyChanged("ListOfCurrentNewsTopics");//?
                }
            }
        }
        List<string> interestsName { get; set; }
       
        

        
        public InterestsPage()
        {
            this.InitializeComponent();

            interestsName = ConstantHelper.InterestsName;
            
          
        }

        private void InterestsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var newsTopic = InterestsList.SelectedItem;
            //if(приложение было запущно ранее)
            //считать информацию из списка
            switch (newsTopic)
            {
                case "Новости":
                    ListOfCurrentNewsTopics = ConstantHelper.news;
                    //CheckingListForSelectedValues(ListOfCurrentNewsTopics, InterestsService.SaveSelectedListBoxItems);
                    break;
                case "Спорт":
                    ListOfCurrentNewsTopics = ConstantHelper.sport;
                    break;
                case "Развлечения":
                    ListOfCurrentNewsTopics = ConstantHelper.entertainment;
                    break;
                case "Бизнес и финансы":
                    ListOfCurrentNewsTopics = ConstantHelper.business;
                    break;
                case "Технологии":
                    ListOfCurrentNewsTopics = ConstantHelper.technologies;
                    break;
                default:
                    ListOfCurrentNewsTopics = null;
                    break;


            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        
    }
}
