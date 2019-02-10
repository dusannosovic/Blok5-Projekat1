using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM1.ViewModel
{
    public class PictureViewModel : BindableBase
    {
        public static List<PictureBitmap> pictures;

        static PictureViewModel(){
            pictures = new List<PictureBitmap>();
        }
        public static List<PictureBitmap> Pictures
        {
            get { return pictures; }
            set
            {
                pictures = value;
            }
        }
        public static void picturesChange(Users user)
        {
            Pictures.Clear();
            foreach(Picture userPic in user.Pictures)
            {
                Pictures.Add(new PictureBitmap(userPic.Uri, userPic.Title, userPic.Description, userPic.Time));
            }
        }

    }
}
