using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Extensions
{
    static class StringExtension
    {
        public static string GetTopicId(this string newsTopic)
        {
            switch (newsTopic)
            {
                case "BBC News":
                    return "bbc-news";
                case "Daily Mail":
                    return "daily-mail";
                case "CNN":
                    return "cnn";
                case "Google News(Russia)":
                    return "google-news-ru";
                case "Hacker News":
                    return "hacker-news";
                case "National Geographic":
                    return "national-geographic";
                case "The Washington Post":
                    return "the-washington-post";
                case "The Wall Street Journal":
                    return "the-wall-street-journal";
                case "BBC Sport":
                    return "bbc-sport";
                default: return null;
            }
        }
    }
}
