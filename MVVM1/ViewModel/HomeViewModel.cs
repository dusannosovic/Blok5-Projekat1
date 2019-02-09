using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM1.ViewModel
{
    public class HomeViewModel : BindableBase
    {
        private string homeViewStartMessage = "Kurac!";
        public MyICommand LoginCommand { get; set; }
        public MyICommand RegisterCommand { get; set; }

        public Users currentUser = new Users();
        public Users curUserLog = null;

        public UserList currentUsers = new UserList();

        public HomeViewModel()
        {
            //Serializer.Serialize(currentUsers);
            LoginCommand = new MyICommand(Login);
            RegisterCommand = new MyICommand(Register);
        }

        public Users CurrentUser
        {
            get { return currentUser; }
            set
            {
                currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        public string HomeViewStartMessage
        {
            get { return homeViewStartMessage; } //return "Hello!";
        }
        public void Login()
        {
            bool valid = false;
            currentUsers = Serializer.Deserialize();

            foreach(Users user in currentUsers.Users)
            {
                if(CurrentUser.Username == user.Username && CurrentUser.Password == user.Password)
                {
                    curUserLog = user;
                }
            }
            CurrentUser.ValidateLogin(currentUsers);
            if (CurrentUser.IsValid)
            {
                MenuViewModel.mode = "l";
                Application.Current.MainWindow.Content = new MenuViewModel();
                MenuViewModel.currentUser = curUserLog;
                PictureViewModel.picturesChange(curUserLog);
            }
        }
        public void Register()
        {
            //currentUsers = Serializer.Deserialize();   
            CurrentUser.Validate();
            if (CurrentUser.IsValid)
            {
                currentUsers = Serializer.Deserialize();
                CurrentUser.ValidateRegister(currentUsers);
                if (CurrentUser.IsValid)
                {
                    MenuViewModel.mode = "r";
                    currentUsers.Users.Add(CurrentUser);
                    curUserLog = CurrentUser;
                    Serializer.Serialize(currentUsers);
                    Application.Current.MainWindow.Content = new MenuViewModel();
                    MenuViewModel.currentUser = CurrentUser;
                }
            }
        }
    }
}
