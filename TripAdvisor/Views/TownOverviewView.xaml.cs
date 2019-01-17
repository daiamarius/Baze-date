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
    /// Interaction logic for TownOverviewView.xaml
    /// </summary>
    public partial class TownOverviewView : UserControl
    {
        public TownOverviewView(string town)
        {
            InitializeComponent();
            Textblock_welcome.Text = town;
            using (var db = new TripAdvisorEntities())
            {
                List<getRestaurants_Result> results = db.getRestaurants(town).ToList();
                Listview_topRestaurants.ItemsSource = results;
            }
        }
    }
}
