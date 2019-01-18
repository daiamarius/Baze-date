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
    public partial class TownOverviewView : UserControl
    {
        private List<getTop3Restaurants_Result> _results;

        public TownOverviewView(string town)
        {
            InitializeComponent();
            using (var db = new TripAdvisorEntities())
            {
                Textblock_bestRestaurants.DataContext = town;
                _results = db.getTop3Restaurants(town).ToList();
                Listview_topRestaurants.ItemsSource = _results;
            }
        }

        private void Listview_topRestaurants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
