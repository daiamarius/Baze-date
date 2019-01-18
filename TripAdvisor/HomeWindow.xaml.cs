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
using System.Windows.Shapes;
using System.ComponentModel;
using TripAdvisor.Views;

namespace TripAdvisor
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public List<string> _orase;
        public HomeWindow()
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

        private void Button_hotel_Click(object sender, RoutedEventArgs e)
        {
            var view = new HotelsView();
            DataContext = view;
        }

        private void Button_activities_Click(object sender, RoutedEventArgs e)
        {
            var view = new ActivitiesView();
            DataContext = view;
        }

        private void Button_restaurants_Click(object sender, RoutedEventArgs e)
        {
            var view = new RestaurantsView(Textbox_Town.Text);
        }

        void HomeWindow_Closing(object sender, CancelEventArgs e)
        {
            _orase.Clear();
            e.Cancel = true;
        }

    }
}
