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
        public static int maxInventory = 9;
        
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

        // Check if MaxInventory reached
        /// <summary>
        /// Check if MaxInventory reached. If not then add object into 
        /// 
        /// </summary>
        /// <param name="gameItem">item to be added to inventory</param>
        /// <returns>
        /// Takes the tally of Size slots and makes sure that it doesn't exceed limit
        /// </returns>
        public bool AddInventoryItem(IPortable gameItem)
        {
            Size += gameItem.Size; // Take the game item and add it to the total Size to see if Size is past MaxInventory
            //InventoryItem item = new InventoryItem(gameItem.ToString());
            if (Size < MaxInventory) // if less than MaxInventory than proceed with adding item to player inventory
            {
                Inventory.Add(gameItem); // add item to inventory
                Calc(); // calculate new Size tally
                return true;
            }
            else
            {
                Size -= gameItem.Size; // reverse game item size from Size
                return false;
            }
           
        }

        // Remove Item from Player Inventory
        /// <summary>
        /// Remove Item from Player Inventory
        /// </summary>
        /// <param name="item">Item in player inventory to be removed</param>
        public void RemoveInventoryItem(IPortable item)
        {
            Inventory.Remove(item);
            Size -= item.Size;
            Calc();
        }

        // Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="location">location of player</param>
        public Player(MapLocation location) 
        {
            Location = location; // set Location of player
            MaxInventory = maxInventory; // Instantiate MaxInventory with maxInventory number
            Size = 0; // set Size to zero
            Inventory = new List<IPortable>();  // Invetory List
        }
    }
}