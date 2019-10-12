using News.Helpers;
using News.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
    public sealed partial class InterestsPage : Page
    {
        List<string> interestsName { get; set; }
        List<int> saveIndexOfSelectedListBoxItems { get; set; }
        ObservableCollection<NewsTopics> listOfCurrentNewsTopics { get; set; }
        
        public InterestsPage()
        {
            this.InitializeComponent();

            interestsName = ConstantHelper.interestsName;
        }

        private void InterestsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var newsTopic = InterestsList.SelectedItem;
            //if(приложение было запущно ранее)
            //считать информацию из списка
            switch (newsTopic)
            {
                case "Новости":
                    listOfCurrentNewsTopics = ConstantHelper.news;
                    break;
                case "Спорт":
                    listOfCurrentNewsTopics = ConstantHelper.sport;
                    break;
                case "Развлечения":
                    listOfCurrentNewsTopics = ConstantHelper.entertainment;
                    break;
                case "Бизнес и финансы":
                    listOfCurrentNewsTopics = ConstantHelper.business;
                    break;
                case "Технологии":
                    listOfCurrentNewsTopics = ConstantHelper.technologies;
                    break;
                default:
                    listOfCurrentNewsTopics.Clear();
                    break;


            }
        }
    }
}
