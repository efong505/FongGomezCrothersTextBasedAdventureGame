using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace TextBasedAdventureGame
{
    public class Player:GameObject
    {
        public static int maxInventory = 6;
        private int inventorySize;

        public MapLocation Location { get; set; }
        

        public int MaxInventory { get; set; }
        



        public List<GameObject> Inventory
        {
            get => Inventory;
            set => Inventory = value;
            //Calc();
        }

        public void Calc()
        {
            MaxInventory = Inventory.Count;
            //foreach (int items in Inventory)
            //{
            //    Inventory[items]
            //}
            
        }

        //public bool AddInventoryItem(IPortable item)
        //{
        //    item.Size = 
        //    if (item < 6)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        add = false;
        //    }
        //    return add;
        //}

        //public List<IPortable> Inventory { get; set; }




        public Player(MapLocation location) 
        {
            Location = location;
            MaxInventory = maxInventory;
            Inventory = null;
        }
    }
}