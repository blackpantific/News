using News.Extensions;
using News.Helpers;
using News.Services;
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

        public async Task<List<Article>> GetNewsByTopic(string newsTopic)
        {   

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(String.Format(ConstantHelper.PathString, 
                    $"sources={newsTopic.GetTopicId()}"));
                var response = await client.GetAsync(client.BaseAddress);

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var deserializedJson = JsonConvert.DeserializeObject<RootJson>(json);
                return await Task.Run(() => (ApiReplyService.SaveNewsSourcesList = deserializedJson.articles));
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
                return null;
            }
        }


    }
}
