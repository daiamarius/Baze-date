using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TripAdvisor.Views;            

namespace TripAdvisor.Views
{
    public partial class RestaurantsView : UserControl
    {
        private List<getRestaurants_Result> _results;
        public RestaurantsView(List<getRestaurants_Result> results)
        {
            _results = results;
            InitializeComponent();
            listView_restaurants.ItemsSource = _results;
        }

        private void listView_restaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index=listView_restaurants.SelectedIndex;
            Window accessed = new RestaurantAccessed(_results[index]);
            accessed.Show();
        }
    }
}
