using News.Helpers;
using News.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace News
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class SourcesPage : Page
    {
        List<string> newsName { get; set; }
        NewsApiService newsApiService;


        private ObservableCollection<Article> newsList;
        public ObservableCollection<Article> NewsList
        {
            get { return newsList; }
            set
            {
                if (newsList != value)
                {
                    newsList = value;
                    OnPropertyChanged("NewsList");
                }
            }
        }

        public SourcesPage()
        {
            this.InitializeComponent();

            newsName = ConstantHelper.NewsName;

            newsApiService = new NewsApiService();





        }

        private async void SourcesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NewsList = new ObservableCollection<Article>(await newsApiService
                .GetNewsByTopic(SourcesList.SelectedItem.ToString()));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
