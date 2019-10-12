﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News
{
    class Article
    {
        public Source Source;
        //The identifier id and a display name 
        //name for the source this article came from.
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string PublishedAt { get; set; }
        public string Content { get; set; }


    }
}