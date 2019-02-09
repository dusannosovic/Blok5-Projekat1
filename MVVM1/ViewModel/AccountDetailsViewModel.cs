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
        UserList userList = null;
        public AccountDetailsViewModel()
        {
            //Serializer.Serialize(currentUsers);
            ChangeCommand = new MyICommand(Change);
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
        public void Change()
        {
            int counter = 0;
            int number = -1;
            CurrentUser.Validate();
            if (CurrentUser.IsValid)
            {
                userList = Serializer.Deserialize();
                CurrentUser.ValidateRegister(userList);
                if (CurrentUser.IsValid)
                {
                    foreach(Users user in userList.Users)
                    {
                        if(user.Username == MenuViewModel.currentUser.Username)
                        {
                            number = counter;
                        }
                        counter++;
                    }
                    userList.Users[number].Username = CurrentUser.Username;
                    userList.Users[number].Password = CurrentUser.Password;
                    MenuViewModel.currentUser = userList.Users[number];
                    Serializer.Serialize(userList);
                }
            }
        }
    }
}
