using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.Model
{
    public class Users : ValidationBase
    {
        private string password;
        private string username;
        private List<Picture> pictures;

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        public List<Picture> Pictures
        {
            get { return pictures; }
            set
            {
                if (pictures != value)
                {
                    pictures = value;
                    OnPropertyChanged("Pictures");
                }
            }
        }
    

    public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Password cannot be empty.";
            }
            else if((int)this.password[0] >= 48 && (int)this.password[0] <= 57)
            {
                this.ValidationErrors["Password"] = "Password cannot start with number";
            }
            if (string.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Username cannot be empty.";
            }
            if (this.password.Length < 6)
            {
                this.ValidationErrors["Password"] = "Password must be longer";
            }
        }
    }
}
