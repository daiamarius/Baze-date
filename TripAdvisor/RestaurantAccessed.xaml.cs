using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Resources;

namespace TripAdvisor
{
    public partial class RestaurantAccessed : Window
    {
        private getRestaurants_Result _result;
        private List<getRestaurantPhotos_Result> _imageList;
        private int _imageIndex;

        public RestaurantAccessed(getRestaurants_Result result)
        {
            InitializeComponent();
            InitializeComponent();
            _result = result;
            Textblock_title.Text = _result.Nume;
            using (var db = new TripAdvisorEntities())
            {
                _imageList = db.getRestaurantPhotos(_result.RestaurantID).ToList();
            }
            _imageIndex = 0;
            if (_result.Poza != null)
            {
                BitmapImage bmpi = new BitmapImage();
                bmpi.BeginInit();
                bmpi.StreamSource = new MemoryStream(_result.Poza);
                bmpi.EndInit();
                Image_imageSlider.Source = bmpi;
                var firstPhoto = new getRestaurantPhotos_Result("Owner","",_result.Poza,null);
                _imageList.Insert(0, firstPhoto);
                Textblock_published.Text = "Published by:" + _result.Nume;
            }
        }

        private void Button_imageLeft_Click(object sender, RoutedEventArgs e)
        {
            if (_imageIndex > 0)
            {
                _imageIndex--;
                BitmapImage bmpi = new BitmapImage();
                bmpi.BeginInit();
                bmpi.StreamSource = new MemoryStream(_imageList[_imageIndex].Poza);
                bmpi.EndInit();
                Image_imageSlider.Source = bmpi;
                Textblock_published.Text = "Published by : " + _imageList[_imageIndex].Nume + " " + _imageList[_imageIndex].Prenume;
            }
        }

        private void Button_imageRight_Click(object sender, RoutedEventArgs e)
        {
            if(_imageIndex+1 < _imageList.Count())
            {
                _imageIndex++;
                BitmapImage bmpi = new BitmapImage();
                bmpi.BeginInit();
                bmpi.StreamSource = new MemoryStream(_imageList[_imageIndex].Poza);
                bmpi.EndInit();
                Image_imageSlider.Source = bmpi;
                Textblock_published.Text = "Published by : " + _imageList[_imageIndex].Nume + " " + _imageList[_imageIndex].Prenume;
            }
        }

        ~RestaurantAccessed()
        {
            _imageList.Clear();
        }
    }
}
