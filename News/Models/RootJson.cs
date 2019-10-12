using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News
{
    class RootJson
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }

        public List<Article> articles { get; set; }
    }
}
