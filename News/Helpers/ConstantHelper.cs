using News.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Helpers
{
  
    class ConstantHelper
    {

        public static readonly List<string> newsName = new List<string>()
            {"BBC News", "Daily Mail", "CNN", "Google News (Russia)",
            "Hacker News", "National Geographic", "The Washington Post",
            "The Wall Street Journal", "BBC Sport"};

        public static readonly List<string> interestsName = new List<string>()
        { "Новости", "Спорт", "Развлечения", "Повседневная жизнь", "Семья и саморазвитие",
            "Бизнес и финансы", "Авто", "Технологии", "Фото и видео", "Страны ЕС" };


        //создание тем для каждого подраздела новостей, страница InterestsPage
        
        //ВНЕСТИ ВСЕ ОБЪЯВЛЕНИЕ В ЦИКЛ И В НЕМ ЗАДАВАТЬ TRUE СВОЙСТВУ IsChecked из списка данных приложения, 
        public static readonly ObservableCollection<NewsTopics> news = new ObservableCollection<NewsTopics>()
        {
            new NewsTopics() { Label = "Главные новости", PicturePath="/TopicNewsImages/breakingnews.jpg", TopicId=0},
            new NewsTopics() { Label = "В мире", PicturePath="/TopicNewsImages/worldnews.jpg", TopicId=1},
            new NewsTopics() { Label = "Культура", PicturePath="/TopicNewsImages/culture.jpg", TopicId=2},
            new NewsTopics() { Label = "Происшествия", PicturePath="/TopicNewsImages/incident.jpg", TopicId=3}
        };

        public static readonly ObservableCollection<NewsTopics> sport = new ObservableCollection<NewsTopics>()
        {
            new NewsTopics() { Label = "Футбол", PicturePath="/TopicNewsImages/football.jpg", TopicId=4},
            new NewsTopics() { Label = "Баскетбол", PicturePath="/TopicNewsImages/basketball.jpg", TopicId=5},
            new NewsTopics() { Label = "Хоккей", PicturePath="/TopicNewsImages/hockey.jpg", TopicId=6}
        };

        public static readonly ObservableCollection<NewsTopics> entertainment = new ObservableCollection<NewsTopics>()
        {
            new NewsTopics() { Label = "Знаменитости", PicturePath="/TopicNewsImages/celebrities.jpg", TopicId=7},
            new NewsTopics() { Label = "Кино и ТВ", PicturePath="/TopicNewsImages/cinema.jpg", TopicId=8},
            new NewsTopics() { Label = "Музыка", PicturePath="/TopicNewsImages/music.jpg", TopicId=9}
        };


        public static readonly ObservableCollection<NewsTopics> business = new ObservableCollection<NewsTopics>()
        {
            new NewsTopics() { Label = "Новости рынков", PicturePath="/TopicNewsImages/marketnews.jpg", TopicId=10},
            new NewsTopics() { Label = "Личные финансы", PicturePath="/TopicNewsImages/finance.jpg", TopicId=11},
            new NewsTopics() { Label = "Недвижимость", PicturePath="/TopicNewsImages/realstate.jpg", TopicId=12}
        };

        public static readonly ObservableCollection<NewsTopics> technologies = new ObservableCollection<NewsTopics>()
        {
            new NewsTopics() { Label = "Наука и техника", PicturePath="/TopicNewsImages/science.jpg", TopicId=13},
            new NewsTopics() { Label = "Хайтек", PicturePath="/TopicNewsImages/hi-tech.jpg", TopicId=14},
            new NewsTopics() { Label = "Астрономия", PicturePath="/TopicNewsImages/astronomy.jpg", TopicId=15},
            new NewsTopics() { Label = "Планета Земля", PicturePath="/TopicNewsImages/planetearth.jpg", TopicId=16}
        };
    }
}
