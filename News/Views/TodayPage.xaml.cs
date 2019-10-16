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
    public sealed partial class TodayPage : Page //, INotifyPropertyChanged
    {
        //public ObservableCollection<string> ListOfUserPreferences { get; private set; }

        //public ObservableCollection<NewsTopics> RefToInterestsServiceList = 
        //    new ObservableCollection<NewsTopics>(InterestsService.SaveSelectedListBoxItems);
        public TodayPage()
        {
            

            this.InitializeComponent();


            //ВЫНЕСТИ В ОТДЕЛЬНЫЙ КЛАСС ДОБАВЛЕНИЯ ЭЛЕМЕНТОВ В PIVOT 
            //GenerateNewsPage.Navigate(typeof(NewsCollectionPage));

            //foreach (var item in InterestsService.SaveSelectedListBoxItems)
            //{
            //    ListOfUserPreferences.Add(item.Label);
            //}

            
          
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName]string prop = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //}
    }
}
