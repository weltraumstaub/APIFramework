using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Models
{
    public partial class ListOfUsersDTO
    {
        public long page { get; set; }
        public long per_page { get; set; }
        public long total { get; set; }
        public long total_pages { get; set; }
        public Datum[] data { get; set; }
        public Support support { get; set; }
    }

    public partial class Datum
    {
        public long id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Uri avatar { get; set; }
    }

    public partial class Support
    {
        public Uri url { get; set; }
        public string text { get; set; }
    }

}
