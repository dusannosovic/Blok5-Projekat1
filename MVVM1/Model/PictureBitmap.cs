using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MVVM1.Model
{
    public class PictureBitmap
    {
        public BitmapImage Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public PictureBitmap(string uri, string title, string description)
        {
            Picture = new BitmapImage(new Uri(uri));
            Title = title;
            Description = description;
        }

    }
}
