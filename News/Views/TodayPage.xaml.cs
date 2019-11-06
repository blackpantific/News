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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace News
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class TodayPage : Page, INotifyPropertyChanged
    {
        NewsApiService newsApiService;

        private ObservableCollection<Article> todayNewsList;
        public ObservableCollection<Article> TodayNewsList
        {
            get { return todayNewsList; }
            set
            {
                if (todayNewsList != value)
                {
                    todayNewsList = value;
                    OnPropertyChanged("TodayNewsList");
                }
            }
        }
        public TodayPage()
        {
            

            this.InitializeComponent();
            newsApiService = new NewsApiService();
            this.DataContext = this;
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private async void NvTopLevelNav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TodayNewsList = new ObservableCollection<Article>(await newsApiService
                .GetNewsByWord(nvTopLevelNav.SelectedItem.ToString()));
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = e.ClickedItem;

            if (Frame.CanGoForward)
            {
                Frame.GoForward();
            }
            else
            {
                Frame.Navigate(typeof(ContentPage), (object)item);

            }
        }
    }
}
