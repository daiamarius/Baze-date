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
        public RestaurantsView(string town)
        {
            InitializeComponent();
            if(town.Count()!=0)
            {
                Textblock_bestRestaurants.DataContext = town;
                using (var db = new TripAdvisorEntities())
                {
                    _results = db.getRestaurants(town).ToList();
                    var foodTypes = db.getPreparate(town).ToList();
                    listView_restaurants.ItemsSource = _results;
                    listView_food.ItemsSource = foodTypes;
                }
            }
        }

        private void listView_restaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index=listView_restaurants.SelectedIndex;
            Window accessed = new RestaurantAccessed(_results[index]);
            accessed.Show();
        }

        private void listView_food_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
