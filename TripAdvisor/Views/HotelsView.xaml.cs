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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TripAdvisor.Views
{
    /// <summary>
    /// Interaction logic for HotelsView.xaml
    /// </summary>
    public partial class HotelsView : UserControl
    {
       private  List<getHotels_Result> _results;
       private List<getHotelRoomPhotos_Result> _roomTypes;
       string _currentTown;
        public HotelsView(string town)
        {

            InitializeComponent();
            if (town.Count() != 0)
            {
                _currentTown = town;
                Textblock_bestHotels.DataContext = town;
                using (var db = new TripAdvisorEntities())
                {
                    _results = db.getHotels(town).ToList();
                    _roomTypes = db.getHotelRoomPhotos(town).ToList();
                    listView_hotels.ItemsSource = _results;
                    listView_rooms.ItemsSource = _roomTypes;
                }
            }

        }

        private void listView_hotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView_hotels.SelectedIndex;
            var usc = new HotelAccessedView(_results[index].CazareID);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }

        private void listView_rooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listView_rooms.SelectedIndex;
            var usc = new ListHotelsView(_currentTown, _roomTypes[index].NumarPaturi);
            HomeWindow2.Instance.GridMain.Children.Add(usc);

        }

        private void Button_seeAll_Click(object sender, RoutedEventArgs e)
        {
            var usc = new ListHotelsView(_currentTown);
            HomeWindow2.Instance.GridMain.Children.Add(usc);
        }
    }
    
}
