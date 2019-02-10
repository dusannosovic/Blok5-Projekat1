using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.Model
{
    public class Picture : ValidationBasePicture
    {
        private string uri;
        private string title;
        private string description;
        private string time;

        public string Uri
        {
            get { return uri; }
            set
            {
                if (uri != value)
                {
                    uri = value;
                    OnPropertyChanged("Uri");
                }
            }
        }
        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        public string Time
        {
            get { return time; }
            set
            {
                if (time != value)
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }

        public Picture()
        {

        }

        public Picture(string uri, string title, string description)
        {
            Uri = uri;
            Title = title;
            Description = description;
            Time = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.uri))
            {
                this.ValidationErrors["Uri"] = "Must add picture";
            }
            if (string.IsNullOrWhiteSpace(this.title))
            {
                this.ValidationErrors["Title"] = "Your picture must have title";
            }
        }
    }
}
