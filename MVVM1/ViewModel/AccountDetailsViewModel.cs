using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.ViewModel
{
    public class AccountDetailsViewModel : BindableBase
    {
        Users currentUser = new Users();
        public MyICommand ChangeCommand { get; set; }
        public MyICommand ChangeCommandPass { get; set; }
        UserList userList = null;
        Users tempuser;
        private string username;
        private string password;
        public AccountDetailsViewModel()
        {
            //Serializer.Serialize(currentUsers);
            ChangeCommand = new MyICommand(Change);
            ChangeCommandPass = new MyICommand(ChangePass);

            tempuser = Serializer.DeserializeUser();
            if(tempuser != null)
            {
                Username = tempuser.Username;
                Password = tempuser.Password;
            }
            //Username = tempuser.Username;
            //Password = tempuser.Password;
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
        public UserList UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public void Change()
        {
            tempuser = Serializer.DeserializeUser();
            int counter = 0;
            int number = -1;
            bool brojac = false;
            CurrentUser.Username = Username;
            //CurrentUser.Password = Password;
            CurrentUser.Validate();
            if (CurrentUser.IsValid)
            {
                userList = Serializer.Deserialize();
                CurrentUser.ValidateRegister(userList);
                if (CurrentUser.IsValid)
                {
                    foreach(Users user in userList.Users)
                    {
                        if(user.Username == tempuser.Username)
                        {
                            number = counter;
                            brojac = true;
                        }
                        counter++;
                    }
                    if (brojac)
                    {
                        userList.Users[number].Username = CurrentUser.Username;
                       // userList.Users[number].Password = CurrentUser.Password;
                        //MenuViewModel.current = userList.Users[number];
                        Serializer.SerializeUser(userList.Users[number]);
                        tempuser = userList.Users[number];
                        Serializer.Serialize(userList);
                        CurrentUser = tempuser;
                    }
                }
            }
        }
        public void ChangePass()
        {
            tempuser = Serializer.DeserializeUser();
            int counter = 0;
            int number = -1;
            bool brojac = false;
            //CurrentUser.Username = Username;
            CurrentUser.Password = Password;
                CurrentUser.ValidatePass();
                userList = Serializer.Deserialize();
                //CurrentUser.ValidateRegister(userList);
                if (CurrentUser.IsValid)
                {
                    foreach (Users user in userList.Users)
                    {
                        if (user.Username == tempuser.Username)
                        {
                            number = counter;
                            brojac = true;
                        }
                        counter++;
                    }
                    if (brojac)
                    {
                        //userList.Users[number].Username = CurrentUser.Username;
                        userList.Users[number].Password = CurrentUser.Password;
                        //MenuViewModel.current = userList.Users[number];
                        Serializer.SerializeUser(userList.Users[number]);
                        tempuser = userList.Users[number];
                        Serializer.Serialize(userList);
                        CurrentUser = tempuser;
                    }
                }
        
        }
    }
}
