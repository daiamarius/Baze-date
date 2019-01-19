using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TripAdvisor.Views
{
    /// <summary>
    /// Interaction logic for RestaurantAccessedView.xaml
    /// </summary>
    public partial class RestaurantAccessedView : UserControl
    {
        private List<getRestaurantPhotos_Result> _imageList;
        private int _imageIndex;

        public RestaurantAccessedView(int restId)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                getRestaurantDetails_Result details = db.getRestaurantDetails(restId).ToList()[0];
                GridDescription.DataContext = details;
                InitalizePhotos(restId, details.Poza);
            }
        }

        private void Button_imageLeft_Click(object sender, RoutedEventArgs e)
        {
            if (_imageIndex > 0)
            {
                _imageIndex--;
                Image_imageSlider.Source = ConvertToImage(_imageList[_imageIndex].Poza);
                Textblock_published.DataContext = _imageList[_imageIndex].Nume + " " + _imageList[_imageIndex].Prenume;
            }
        }

        private void Button_imageRight_Click(object sender, RoutedEventArgs e)
        {
            if (_imageIndex + 1 < _imageList.Count())
            {
                _imageIndex++;
                Image_imageSlider.Source = ConvertToImage(_imageList[_imageIndex].Poza);
                Textblock_published.DataContext = _imageList[_imageIndex].Nume + " " + _imageList[_imageIndex].Prenume;
            }
        }

        ~RestaurantAccessedView()
        {
            _imageList.Clear();
        }

        public BitmapImage ConvertToImage(byte [] array)
        {
            BitmapImage bmpi = new BitmapImage();
            bmpi.BeginInit();
            bmpi.StreamSource = new MemoryStream(array);
            bmpi.EndInit();
            return bmpi;
        }

        private void InitalizePhotos(int restId, byte[] poza)
        {
            using (var db = new TripAdvisorEntities())
            {
                _imageList = db.getRestaurantPhotos(restId).ToList();
                var menuList = db.getRestaurantMenu(restId).ToList();
                int i = 0;
                String menu = "";
                while (i < menuList.Count())
                {
                    menu = menu + menuList[i].ToString() + ", ";
                    i++;
                }
                Textblock_menu.Text = menu;
            }
            _imageIndex = 0;
            if (poza != null)
            {
                Image_imageSlider.Source = ConvertToImage(poza);
                var firstPhoto = new getRestaurantPhotos_Result("Owner", "", poza, null);
                _imageList.Insert(0, firstPhoto);
                Textblock_published.DataContext = "Owner";
            }
        }
    }
}
