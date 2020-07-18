// Player.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;

namespace TextBasedAdventureGame
{
    public class Player:GameObject,IPortable
    {
        /// <summary>
        /// static int maxInventory field
        /// </summary>
        public static int maxInventory = 6;
        
        // size of Player's Inventory
        /// <summary>
        /// Size Property of Player's Inventory
        /// </summary>
        public int Size { get; set; }

        // Maplocation property
        /// <summary>
        /// MapLocation Location Property
        /// Location of player
        /// </summary>
        public MapLocation Location { get; set; }
        
        /// <summary>
        /// Max Inventory Property
        /// </summary>
        public int MaxInventory { get; set; }
        /// <summary>
        /// List of Game Objects Property
        /// </summary>
        public List<GameObject> GameObjects { get; set; }
        
        // Player's Portable Inventory 
        /// <summary>
        /// Inventory IPortable Property
        /// </summary>
        public List<IPortable> Inventory { get; set; }
       

        /// <summary>
        /// Calculate the number of slots the Objects in the player's 
        /// inventory is taking up
        /// </summary>
        public void Calc()
        {
            Size = 0; // Reset the Size so that can count the current number 
            for (int count = 0; count < Inventory.Count; count++)
            {
                
                Size += Inventory[count].Size; // Check each item's Size and add it to total Size
                
            }
        }

        /// <summary>
        /// Check if MaxInventory reached. If not then add object into 
        /// 
        /// </summary>
        /// <param name="gameItem"></param>
        /// <returns></returns>
        public bool AddInventoryItem(IPortable gameItem)
        {
            Size += gameItem.Size;
            //InventoryItem item = new InventoryItem(gameItem.ToString());
            if (Size < MaxInventory)
            {
                Inventory.Add(gameItem);
                
                Calc();
                return true;
            }
            else
            {
                Size -= gameItem.Size;
                return false;
            }
           
        }

        public void RemoveInventoryItem(IPortable item)
        {
            Inventory.Remove(item);
            Size -= item.Size;
            Calc();
        }

        public Player(MapLocation location) 
        {
            Location = location;
            MaxInventory = maxInventory;
           // GameObjects = new List<GameObject>();
            Size = 0;
            Inventory = new List<IPortable>(); 
             
            
             
        }
    }
}