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
        private List<Picture> pictures = new List<Picture>();

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
            if (string.IsNullOrWhiteSpace(this.username))
            {
                this.ValidationErrors["Username"] = "Username cannot be empty.";
            }
            else if ((int)this.username[0] >= 48 && (int)this.username[0] <= 57)
            {
                this.ValidationErrors["Username"] = "Username cannot start with number";
            }
        }

        protected override void ValidateSelfList(UserList users)
        {
            bool usernameverify = false;
            foreach (Users user in users.Users)
            {
                if (this.username == user.Username)
                    usernameverify = true;
            }
            if (usernameverify)
            {
                this.ValidationErrors["Username"] = "Username already exist";
            }
        }

        protected override void ValidateSelfListLogin(UserList users)
        {
            bool passwordverify = false;
            bool usernameverify = false;
            foreach(Users user in users.Users)
            {
                if (user.username == this.username && user.password != this.password)
                {
                    passwordverify = true;
                    usernameverify = false;
                }
                else if (user.username == this.username && user.password == this.password)
                {
                    passwordverify = true;
                    usernameverify = true;
                }
            }

            if (passwordverify && !usernameverify)
                this.ValidationErrors["Password"] = "Wrong password";
            if (!passwordverify && !usernameverify)
                this.ValidationErrors["Username"] = "Wrong username";
        }

        protected override void ValidateSelfPass()
        {
            if (string.IsNullOrWhiteSpace(this.password))
            {
                this.ValidationErrors["Password"] = "Password cannot be empty.";
            }
            else if (this.password.Length < 6)
            {
                this.ValidationErrors["Password"] = "Password must be longer";
            }
        }
    }
}
