﻿using System;
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
        private static HomeWindow2 _instance;
        public string _orasCurent;
        public List<string> _orase;
        private Utilizatori _currentUser;

        public static HomeWindow2 Instance
        {
            get
            {
                return _instance;
            }
        }

        public static HomeWindow2 createInstance(int userId)
        {
                if (_instance == null)
                    _instance = new HomeWindow2(userId);
                return _instance;
        }

        private HomeWindow2(int userId)
        {
            InitializeComponent();
            using (var context = new TripAdvisorEntities())
            {
                var orase = from c in context.Orase
                            orderby c.Nume
                            select c.Nume;
                _currentUser = (from x in context.Utilizatori
                                where x.UserID == userId
                                select new { Nume = x.Nume, Email = x.Email, Prenume = x.Prenume, Poza = x.Poza }).ToList()
                                .Select(x => new Utilizatori { Nume = x.Nume, Email = x.Email, Prenume = x.Prenume, Poza = x.Poza }).FirstOrDefault();
                Textblock_user.Text = _currentUser.Nume + " " + _currentUser.Prenume;
                Grid_user.DataContext = _currentUser;
                _orase = orase.ToList();
            }
            GridMain.Children.Add(new FirstView());
            Textbox_Town.TextChanged += new TextChangedEventHandler(Textbox_Town_TextChanged);
        }

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_openMenu_Click(object sender, RoutedEventArgs e)
        {
            Button_openMenu.Visibility = Visibility.Hidden;
            Button_UserAccount.Visibility = Visibility.Visible;
            Button_closeMenu.Visibility = Visibility.Visible;
        }

        private void Button_closeMenu_Click(object sender, RoutedEventArgs e)
        {
            Button_openMenu.Visibility = Visibility.Visible;
            Button_closeMenu.Visibility = Visibility.Hidden;
            Button_UserAccount.Visibility = Visibility.Hidden;
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
                    GridMain.Children.Clear();
                     GridMain.Children.Add(usc);
                    break;
                case "ItemAtivities":
                    usc = new ActivitiesView();
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemHotels":
                    usc = new HotelsView(Textbox_Town.Text);
                    GridMain.Children.Clear();
                    GridMain.Children.Add(usc);
                    break;
                case "ItemHome":
                    usc = new TownOverviewView(Textbox_Town.Text);
                    GridMain.Children.Clear();
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

        private void Button_UserAccount_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new AccountSettings();
            GridMain.Children.Add(usc);
        }
    }
}
