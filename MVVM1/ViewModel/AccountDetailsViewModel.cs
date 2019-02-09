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
        MyICommand LoginCommand;
        public AccountDetailsViewModel()
        {
            //Serializer.Serialize(currentUsers);
            LoginCommand = new MyICommand(Change);
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
        public void Change()
        {

        }
    }
}
