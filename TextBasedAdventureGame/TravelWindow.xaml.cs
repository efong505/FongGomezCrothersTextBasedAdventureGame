﻿// TravelWindow.xamal.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 

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

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Window that shows player where they are and provides capability to move from location to location in the map.
    /// </summary>
    public partial class TravelWindow : Window
    {
        /// <summary>
        /// Game object that has map
        /// </summary>
        Map game;
        Player player;

        /// <summary>
        /// Initialize the form, the game and call display location to start the form.
        /// </summary>
        public TravelWindow()
        {
            InitializeComponent();
            game = new Map();
            player = new Player(game.PlayerLocation);
            DisplayLocation();
        }

        /// <summary>
        /// Tells the player where they are.
        /// </summary>
        private void DisplayLocation()
        {
            txbLocationDescription.Text = game.PlayerLocation.Description;
            lbTraveOptions.ItemsSource = game.PlayerLocation.TravelOptions;
            lbItemTakeSearch.ItemsSource = game.PlayerLocation.Items;

        }

        /// <summary>
        /// Double click a travel option to move to a new location on the map.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbTraveOptions_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TravelOption to = (TravelOption)lbTraveOptions.SelectedItem;
            game.PlayerLocation = to.Location;
            DisplayLocation();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            PortableHidingPlace to = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;
            
            lbItemTakeSearch.ItemsSource = game.PlayerLocation.HiddenObjects;
            //PortableHidingPlace to = (PortableHidingPlace)game.PlayerLocation.Items;
            //lbItemTakeSearch.ItemsSource = to.HiddenObject;
            // game.PlayerLocation.Items = to.Search(to);
            //lbItemTakeSearch.ItemsSource = to.Search();


        }
        
    }
}
