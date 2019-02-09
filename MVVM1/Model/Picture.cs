using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.Model
{
    public class Picture
    {
        public string Uri { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Picture()
        {

        }

        public Picture(string uri, string title, string description)
        {
            Uri = uri;
            Title = title;
            Description = description;
        }
    }
}
