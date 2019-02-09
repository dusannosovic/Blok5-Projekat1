using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM1.ViewModel
{
    class MenuViewModel : BindableBase
    {
        
        public MyICommand<string> NavCommand { get; private set; }
        private StudentViewModel studentViewModel = new StudentViewModel();
        private PictureViewModel pictureViewModel = new PictureViewModel();
        private AccountDetailsViewModel accountDetailsViewModel = new AccountDetailsViewModel();
        private BindableBase currentViewModel;
        public static Users currentUser;

        public MenuViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            //CurrentViewModel = homeViewModel;
            CurrentViewModel = pictureViewModel;
            //CurrentViewModel = accountDetailsViewModel;
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "picView":
                    CurrentViewModel = pictureViewModel;
                    break;
                case "addPic":
                    CurrentViewModel = studentViewModel;
                    break;
                case "accountDet":
                    CurrentViewModel = accountDetailsViewModel;
                    break;
            }
        }
        
    }
}

