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

        public int Size { get; set; }
        public MapLocation Location { get; set; }
        

        public int MaxInventory { get; set; }
        
        public List<GameObject> GameObjects { get; set; }



        public List<GameObject> Inventory
        {
            get => Inventory;
            set { Inventory = value; Calc(); }
            
        }

        public void Calc()
        {
            //for(int count = 0; count < Inventory.Count; count++)
            //{
                Size = Inventory.Count;
            //}
            
            
            
        }

        public bool AddInventoryItem( GameObject gameItem)
        {

            if (Size < MaxInventory)
            {

                GameObjects.Add(gameItem);
                return true;
            }
            else
            {
                return false;
            }
            

        }


            public Player(MapLocation location) 
        {
            Location = location;
            MaxInventory = maxInventory;
            
            //Inventory = null;
        }
    }
}