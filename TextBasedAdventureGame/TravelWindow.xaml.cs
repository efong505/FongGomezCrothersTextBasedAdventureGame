// TravelWindow.xamal.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
        // Item objects
        InventoryItem Invitem; 
        HidingPlace Hidingitem;
        PortableHidingPlace Portitem;

        // game and player object
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
            Invitem = new InventoryItem("Pocket Lint");
            Hidingitem = new HidingPlace(Invitem.Description);
            Portitem = new PortableHidingPlace("Pocket Lint", 1, Invitem);
            Invitem = new InventoryItem("Pocket Lint");
            DisplayLocation();
        }

        // Display Location
        /// <summary>
        /// Tells the player where they are.
        /// </summary>
        private void DisplayLocation()
        {
            txbLocationDescription.Text = game.PlayerLocation.Description;
            lbTraveOptions.ItemsSource = game.PlayerLocation.TravelOptions;
            lbItemTakeSearch.ItemsSource = game.PlayerLocation.Items;
        }

        // List Box double click travel option to move to new location on map
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

        // Search button event handler
        /// <summary>
        /// Search button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            // check if item is not an Inventory Item
            if (CheckType(lbItemTakeSearch.SelectedItem) != 1) 
            {
                // Hidden Object
                if(CheckType(lbItemTakeSearch.SelectedItem)== 2) // check if Hidden object
                {
                    HidingPlace hiding = (HidingPlace)lbItemTakeSearch.SelectedItem;
                    game.PlayerLocation.Items[lbItemTakeSearch.SelectedIndex] =  hiding.Search();
                    lbItemTakeSearch.Items.Refresh();
                    //UpdateDisplay();
                }
                // Portable Hiding Obeject
                else if(CheckType(lbItemTakeSearch.SelectedItem)==3) // check if portabalhidden object
                {
                    PortableHidingPlace portHiding = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;
                    game.PlayerLocation.Items[lbItemTakeSearch.SelectedIndex] = portHiding.Search();
                    lbItemTakeSearch.Items.Refresh();
                }
                ClearGameStatus(); // Clear GameStatus List box
                UpdateDisplay(); // Update Disaplay
            }
            else
            {
                // Clear Game Status List box
                ClearGameStatus();
                lbGameStatus.Items.Add(new InventoryItem("Not a hiding object")); // displays message in game status listbox that not a hiding object
            }
        }

        // check if object is Portable
        /// <summary>
        /// Takes in GameObject Inventory, PortableHidingPlace, and Hiding Places Types and 
        /// determines of not Portable returning true or false. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True or false whether or not IPortable typed object</returns>
        private bool isIPortable(object obj)
        {
            if (obj is IPortable)
            {
                return true;
            }
            else
                return false;
        }

        // check which portable type object is
        /// <summary>
        /// Takes portable typed objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// returns the type of game objects each are by index of 
        /// 1-3.
        /// </returns>
        public int CheckType(object obj)
        {
            if (obj is InventoryItem)
                return 1;
            else if (obj is HidingPlace)
                return 2;
            else if (obj is PortableHidingPlace)
                return 3;
            else return 4;
        }
        

        // Button click event
        /// <summary>
        /// Button click event allows user to select an item in the list box of take
        /// and determine whether or not object is portable or not. 
        /// if not portable return message in game result list box that object is not 
        /// portable. If portable, determines which object type it is and then 
        /// takes object and places them into the players inventory.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTake_Click(object sender, RoutedEventArgs e)
        {
            // check if portable
            if (isIPortable(lbItemTakeSearch.SelectedItem))
            {
                // checkt the type selected item is and use switch to choose correct selected item type
                int type = CheckType(lbItemTakeSearch.SelectedItem);
                switch (type)
                {
                    case 1: // InventoryItem type
                        lbItemDrop.ItemsSource = player.Inventory;

                        Invitem = (InventoryItem)lbItemTakeSearch.SelectedItem; // cast selected item to InventoryItem
                        
                        if (player.AddInventoryItem(Invitem)) // check if item will Max player inventory and then add item to player inventory
                        {
                            game.PlayerLocation.Items.Remove(Invitem); // remove item from location
                            lbItemTakeSearch.Items.Refresh(); // refresh 
                            ClearGameStatus(); // clear left over GameStatus in GameResult List box
                        }
                        else // if inventory Max reached then add message that reached max in gamestatus listbox
                        {
                            ClearGameStatus();
                            lbGameStatus.Items.Add(new InventoryItem("You've reached the maximum of your inventory limit"));
                        }
                        break;

                    case 2: // Non Portable type (HidingPlace) == leave not portable message
                        ClearGameStatus();
                        lbGameStatus.Items.Add(new InventoryItem("Item is not portable"));
                        break;

                    case 3: // PortableHidingPlace type
                        lbItemDrop.ItemsSource = player.Inventory;
                        Portitem = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;

                        if (player.AddInventoryItem(Portitem))
                        {
                            game.PlayerLocation.Items.Remove(Portitem);
                            lbItemTakeSearch.Items.Refresh();
                        }
                        else if (player.AddInventoryItem((InventoryItem)Portitem.HiddenObject))
                        {
                            game.PlayerLocation.Items.Remove(Portitem);
                            lbItemTakeSearch.Items.Refresh();
                        }
                        ClearGameStatus();
                        break;
                }
            }
            else
            {
                ClearGameStatus();
                lbGameStatus.Items.Add(new InventoryItem("Item is not portable"));
            }

            lbItemDrop.Items.Refresh();
            lbItemTakeSearch.Items.Refresh();
            UpdateDisplay();
        }

        // Remove from player inventory and drop at location
        /// <summary>
        /// Remove from player inventory and drop at location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            if(CheckType(lbItemDrop.SelectedItem) == 3) // PortabalHidingPlace 
            {
                Portitem = (PortableHidingPlace)lbItemDrop.SelectedItem;
                player.RemoveInventoryItem(Portitem);
                game.PlayerLocation.Items.Add(Portitem);
            }
            else 
            {
                // InventoryItem
                Invitem = (InventoryItem)lbItemDrop.SelectedItem;
                player.RemoveInventoryItem(Invitem);
                game.PlayerLocation.Items.Add(Invitem);
            }
            //update screen
            ClearGameStatus();
            lbItemTakeSearch.Items.Refresh();
            UpdateDisplay();
        }

        // Update display method
        /// <summary>
        /// Update display method
        /// </summary>
        private void UpdateDisplay()
        {
            //lbItemTakeSearch.Items.Refresh();
            lbTraveOptions.Items.Refresh();
            txbLocationDescription.Text = game.PlayerLocation.Description;
            lbItemDrop.Items.Refresh();
        }

        // Clear Game Status
        /// <summary>
        /// Clear Game Status 
        /// </summary>
        private void ClearGameStatus()
        {
            if (!lbGameStatus.Items.IsEmpty)
                lbGameStatus.Items.Clear();
        }
        #region Other Checker
        //// Check with object type and then 
        //public void Checker(object obj)
        //{
        //    if (obj is InventoryItem)
        //    {
        //        lbItemDrop.ItemsSource = player.Inventory;

        //        Invitem = (InventoryItem)lbItemTakeSearch.SelectedItem;
        //        //if(player.Inventory != null)
        //        //{
        //        if (player.AddInventoryItem(Invitem))
        //        {
        //            game.PlayerLocation.Items.Remove(Invitem);
        //            lbItemTakeSearch.Items.Refresh();
        //            //player.AddInventoryItem(item);
        //        }
        //    }
        //    else if (obj is HidingPlace)
        //    {
        //        lbItemDrop.ItemsSource = player.Inventory;

        //        Hidingitem = (HidingPlace)lbItemTakeSearch.SelectedItem;
        //        //if(player.Inventory != null)
        //        //{

        //        if (player.AddInventoryItem((InventoryItem)Hidingitem.HiddenObject))
        //        {
        //            game.PlayerLocation.Items.Remove(Hidingitem);
        //            lbItemTakeSearch.Items.Refresh();
        //            //player.AddInventoryItem(item);
        //        }
        //    }
        //    else if (obj is PortableHidingPlace)
        //    {
        //        lbItemDrop.ItemsSource = player.Inventory;

        //        Portitem = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;
        //        //if(player.Inventory != null)
        //        //{

        //        if (player.AddInventoryItem((InventoryItem)Portitem.HiddenObject))
        //        {
        //            game.PlayerLocation.Items.Remove(Portitem);
        //            lbItemTakeSearch.Items.Refresh();
        //        }
        //    }
        //}
        #endregion  
    }

}
