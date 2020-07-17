// TravelWindow.xamal.cs
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
        InventoryItem item;
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
            lbItemTakeSearch.ItemsSource = game.PlayerLocation.Items;
            item = new InventoryItem("Pocket Lint");
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
           // UpdateDisplay();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            //game.PlayerLocation.HiddenObjects = game.PlayerLocation.HiddenObjects; 

            //TODO: Determine type of game object 
            //TODO: Once determined then do if/else or switch for each type
             //attribute = lbItemTakeSearch.SelectedItem.GetType();

            if (lbItemTakeSearch.SelectedItem.GetType() == PortableHidingPlace)
            {
                attribute to = (attribute)lbItemTakeSearch.SelectedItem;
            }

            PortableHidingPlace to = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;
            game.PlayerLocation.Items[lbItemTakeSearch.SelectedIndex] = to.HiddenObject;
            //lbItemTakeSearch.ItemsSource = game.PlayerLocation.HiddenObjects;
            //PortableHidingPlace to = (PortableHidingPlace)game.PlayerLocation.Items;
            //lbItemTakeSearch.ItemsSource = to.HiddenObject;
            // game.PlayerLocation.Items = to.Search(to);
            //lbItemTakeSearch.ItemsSource = to.Search();
            //UpdateDisplay();
            //bool Testing;
            //InventoryItem test = new InventoryItem("Testing");
            //test.Size = 21;
            //Testing = player.AddInventoryItem(test);
            
        }

        private void lbItemTakeSearch_buttonPress(object sender, MouseButtonEventArgs e)
        {
            //if(player.AddInventoryItem())
        }

        private void btnTake_Click(object sender, RoutedEventArgs e)
        {
           
            
            lbItemDrop.ItemsSource = player.Inventory;
            item = (InventoryItem)lbItemTakeSearch.SelectedItem;
            //if(player.Inventory != null)
            //{
                if (player.AddInventoryItem(item))
                {
                game.PlayerLocation.Items.Remove(item);
                lbItemTakeSearch.Items.Refresh();    
                    //player.AddInventoryItem(item);
                }
                
            //}
          

           
            lbItemDrop.Items.Refresh();
            lbItemTakeSearch.Items.Refresh();
            //GameObject selectobject = new GameObject();
            //selectobject.Description = lbItemTakeSearch.SelectedItem.ToString();
            //// game.PlayerLocation.
            UpdateDisplay();
        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            item = (InventoryItem)lbItemDrop.SelectedItem;
            player.RemoveInventoryItem(item);
            game.PlayerLocation.Items.Add(item);
            lbItemTakeSearch.Items.Refresh();
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            //lbItemTakeSearch.Items.Refresh();
            lbTraveOptions.Items.Refresh();
            txbLocationDescription.Text = game.PlayerLocation.Description;
            lbItemDrop.Items.Refresh();
           // lbItemTakeSearch.ItemsSource = game.PlayerLocation.Items;

        }
    }
}
