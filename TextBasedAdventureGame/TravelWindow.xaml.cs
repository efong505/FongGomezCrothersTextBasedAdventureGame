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
        InventoryItem Invitem;
        HidingPlace Hidingitem;
        PortableHidingPlace Portitem;
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
            Invitem = new InventoryItem("Pocket Lint");
            Hidingitem = new HidingPlace(Invitem.Description);
            Portitem = new PortableHidingPlace("Pocket Lint", 1, Invitem);
            Invitem = new InventoryItem("Pocket Lint");
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

            if (CheckType(lbItemTakeSearch.SelectedItem) != 1)
            {
                if(CheckType(lbItemTakeSearch.SelectedItem)== 2)
                {
                    HidingPlace hiding = (HidingPlace)lbItemTakeSearch.SelectedItem;
                    game.PlayerLocation.Items[lbItemTakeSearch.SelectedIndex] =  hiding.Search();
                    lbItemTakeSearch.Items.Refresh();
                    //UpdateDisplay();
                }

                else if(CheckType(lbItemTakeSearch.SelectedItem)==3)
                {
                    PortableHidingPlace portHiding = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;
                    game.PlayerLocation.Items[lbItemTakeSearch.SelectedIndex] = portHiding.HiddenObject;
                }
                ClearGameStatus();
                UpdateDisplay();
            }
            else
            {
                ClearGameStatus();
                lbGameStatus.Items.Add(new InventoryItem("Not a hiding object"));
            }
            //game.PlayerLocation.HiddenObjects = game.PlayerLocation.HiddenObjects; 

            //TODO: Determine type of game object 
            //TODO: Once determined then do if/else or switch for each type
            //attribute = lbItemTakeSearch.SelectedItem.GetType();

            //if (lbItemTakeSearch.SelectedItem.GetType() == PortableHidingPlace)
            //{
            //    attribute to = (attribute)lbItemTakeSearch.SelectedItem;
            //}

            //PortableHidingPlace to = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;
            //game.PlayerLocation.Items[lbItemTakeSearch.SelectedIndex] = to.HiddenObject;
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
                CheckType(lbItemTakeSearch.SelectedItem);
                int type = CheckType(lbItemTakeSearch.SelectedItem);
                switch (type)
                {
                    case 1:
                        lbItemDrop.ItemsSource = player.Inventory;

                        Invitem = (InventoryItem)lbItemTakeSearch.SelectedItem;
                        //if(player.Inventory != null)
                        //{
                        if (player.AddInventoryItem(Invitem))
                        {
                            game.PlayerLocation.Items.Remove(Invitem);
                            lbItemTakeSearch.Items.Refresh();
                            //player.AddInventoryItem(item);
                        }
                        ClearGameStatus();
                        break;
                    case 2:
                        ClearGameStatus();
                        lbGameStatus.Items.Add(new InventoryItem("Item is not portable"));
                        //lbItemDrop.ItemsSource = player.Inventory;

                        //Hidingitem = (HidingPlace)lbItemTakeSearch.SelectedItem;
                        ////if(player.Inventory != null)
                        ////{

                        //if (player.AddInventoryItem((InventoryItem)Hidingitem.HiddenObject))
                        //{
                        //    game.PlayerLocation.Items.Remove(Hidingitem);
                        //    lbItemTakeSearch.Items.Refresh();
                        //    //player.AddInventoryItem(item);
                        //}


                        break;
                    case 3:
                        lbItemDrop.ItemsSource = player.Inventory;

                        Portitem = (PortableHidingPlace)lbItemTakeSearch.SelectedItem;
                        //if(player.Inventory != null)
                        //{

                        if (player.AddInventoryItem((InventoryItem)Portitem.HiddenObject))
                        {
                            game.PlayerLocation.Items.Remove(Portitem);
                            lbItemTakeSearch.Items.Refresh();
                        }
                        ClearGameStatus();
                        break;
                        //case 4:
                        //    lbGameStatus.Items.Add(new InventoryItem("Item is not portable"));
                        //    break;
                }
            }
            else
            {
                ClearGameStatus();
                lbGameStatus.Items.Add(new InventoryItem("Item is not portable"));
            }
            //lbItemDrop.ItemsSource = player.Inventory;

            //item = (InventoryItem)lbItemTakeSearch.SelectedItem;
            ////if(player.Inventory != null)
            ////{
            //    if (player.AddInventoryItem(item))
            //    {
            //    game.PlayerLocation.Items.Remove(item);
            //    lbItemTakeSearch.Items.Refresh();    
            //        //player.AddInventoryItem(item);
            //    }

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
            Invitem = (InventoryItem)lbItemDrop.SelectedItem;
            player.RemoveInventoryItem(Invitem);
            game.PlayerLocation.Items.Add(Invitem);
            ClearGameStatus();
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
           // lbItemTakeSearch.Items.Refresh();
        }

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
