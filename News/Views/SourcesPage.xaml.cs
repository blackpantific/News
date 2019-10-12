using News.Helpers;
using System.Collections.Generic;
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

        public SourcesPage()
        {
            this.InitializeComponent();

            newsName = ConstantHelper.newsName;

            newsApiService = new NewsApiService();





        }

        private void SourcesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            newsApiService.GetNewsByTopic(SourcesList.SelectedItem.ToString());
        }
    }
}
