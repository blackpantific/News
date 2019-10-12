using News.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace News
{
    class NewsApiService
    {

        public async void GetNewsByTopic(string newsTopic)
        {   
            var path = $"https://newsapi.org/v2/everything?sources={newsTopic.GetTopicId()}&apiKey=562af3f4f64141dfbe20f2d60844a6b0";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(path);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var deserializedJson = JsonConvert.DeserializeObject<RootJson>(json);



            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
            }
        }


    }
}
