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
using TripAdvisor.Views;

namespace TripAdvisor
{
    /// <summary>
    /// Interaction logic for HomeWindow2.xaml
    /// </summary>
    public partial class HomeWindow2 : Window
    {
        public string _orasCurent;
        public List<string> _orase;
        public HomeWindow2()
        {
            InitializeComponent();
            using (var context = new TripAdvisorEntities())
            {
                var orase = from c in context.Orase
                            orderby c.Nume
                            select c.Nume;
                _orase = orase.ToList();
            }
            Textbox_Town.TextChanged += new TextChangedEventHandler(Textbox_Town_TextChanged);
        }

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_openMenu_Click(object sender, RoutedEventArgs e)
        {
            Button_openMenu.Visibility = Visibility.Hidden;
            Button_closeMenu.Visibility = Visibility.Visible;
        }

        private void Button_closeMenu_Click(object sender, RoutedEventArgs e)
        {
            Button_openMenu.Visibility = Visibility.Visible;
            Button_closeMenu.Visibility = Visibility.Hidden;
        }

        private void Listbox_Town_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listbox_Town.ItemsSource != null)
            {
                Listbox_Town.Visibility = Visibility.Collapsed;
                Textbox_Town.TextChanged -= new TextChangedEventHandler(Textbox_Town_TextChanged);
                if (Listbox_Town.SelectedIndex != -1)
                {
                    Textbox_Town.Text = Listbox_Town.SelectedItem.ToString();
                    Listbox_Town.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void Textbox_Town_TextChanged(object sender, TextChangedEventArgs e)
        {
            string typedString = Textbox_Town.Text;
            List<string> autoList = new List<string>();
            autoList.Clear();

            foreach (string item in _orase)
            {
                if (!string.IsNullOrEmpty(Textbox_Town.Text))
                {
                    if (item.ToLower().StartsWith(typedString.ToLower()))
                    {
                        autoList.Add(item);
                    }
                }
            }
            if (autoList.Count > 0)
            {
                Listbox_Town.ItemsSource = autoList;
                Listbox_Town.Visibility = Visibility.Visible;
            }
            else if (Textbox_Town.Text.Equals(""))
            {
                Listbox_Town.Visibility = Visibility.Collapsed;
                Listbox_Town.ItemsSource = null;
            }
            else
            {
                Listbox_Town.Visibility = Visibility.Collapsed;
                Listbox_Town.ItemsSource = null;
            }
        }

        private void Listview_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridMain.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemRestaurants":
                    usc = new RestaurantsView(Textbox_Town.Text);
                     GridMain.Children.Add(usc);
                    break;
                case "ItemAtivities":
                    usc = new ActivitiesView();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemHotels":
                    usc = new HotelsView();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemHome":
                    usc = new TownOverviewView(Textbox_Town.Text);
                    GridMain.Children.Add(usc);
                    break;
                default:
                    break;
            }
        }

        private void Button_account_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_closeWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_minimizeWindow_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_searchTown_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Textbox_Town.Text);
            if(Textbox_Town.Text.Count()!=0)
            {
                _orasCurent = Textbox_Town.Text;
                GridMain.Children.Clear();
                UserControl usc = new TownOverviewView(_orasCurent);
                GridMain.Children.Add(usc);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
