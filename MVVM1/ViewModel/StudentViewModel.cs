using Microsoft.Win32;
using MVVM1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace MVVM1.ViewModel
{
    public class StudentViewModel : BindableBase
    {
        public Users user { get; set; }
        public UserList allUsers { get; set; }
        public MyICommand BrowseCommand { get; set; }
        public MyICommand AddCommand { get; set; }
        private string description;
        private string title;
        string uri;
        BitmapSource bitmapSource;

        public StudentViewModel()
        {
            user = MenuViewModel.currentUser;
            BrowseCommand = new MyICommand(OnBrowse);
            AddCommand = new MyICommand(OnAdd);
            Bitmap bitmap = (Bitmap)Bitmap.FromFile(@"C:\Users\pc\Desktop\Blok5-Projekat1\MVVM1\bin\Debug\addLogo.png", true);
            bitmapSource = BitmapConversion.BitmapToBitmapSource(bitmap);
        }

        public BitmapSource ButtonSource
        {
            get { return bitmapSource; }
            set
            {
                bitmapSource = value;
                OnPropertyChanged("ButtonSource");
            }
        }


        public string Description
        {
            get { return description; }
            set
            {
                if(description!=value)
                {
                    description = value;
                    OnPropertyChanged("Description");
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

        private void OnAdd()
        {
            int count = 0;
            int number = -1;
            Picture tempPic = new Picture(uri, Title, Description);
            user.Pictures.Add(new Picture(uri, Title, Description));
            PictureViewModel.picturesChange(user);
            allUsers = Serializer.Deserialize();
            foreach(Users tempuser in allUsers.Users)
            {
                if(tempuser.Username == user.Username)
                {
                    number = count;
                }
                count++;
            }
            allUsers.Users[number].Pictures.Add(tempPic);
            Serializer.Serialize(allUsers);
        }
        private void OnBrowse()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Bitmap bitmap = (Bitmap)Bitmap.FromFile(op.FileName, true);
                ButtonSource = BitmapConversion.BitmapToBitmapSource(bitmap);
                uri = op.FileName;
            }

        }
        

    }
    public static class BitmapConversion
    {
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }
        public static string ImageToBase64(BitmapSource bitmap)
        {
            var encoder = new PngBitmapEncoder();
            var frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }

    }
}
