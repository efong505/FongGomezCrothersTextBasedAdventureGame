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
        /// <summary>
        /// Size Property
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// MapLocation Location Property
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
        

        /// <summary>
        /// Inventory IPortable Property
        /// </summary>
        public List<IPortable> Inventory { get; set; }
       

        /// <summary>
        /// Calculate the size of the objects in the Inventory
        /// </summary>
        public void Calc()
        {
            
            for (int count = 0; count < Inventory.Count; count++)
            {
                Size += Inventory[count].Size;
                
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
            //InventoryItem item = new InventoryItem(gameItem.ToString());
            if (Size < MaxInventory)
            {
                Inventory.Add(gameItem);
                Size += gameItem.Size;
                Calc();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void RemoveInventoryItem(IPortable item)
        {
            Inventory.Remove(item);
            Calc();
        }

        public Player(MapLocation location) 
        {
            Location = location;
            MaxInventory = maxInventory;
           // GameObjects = new List<GameObject>();
            Size = 1;
            Inventory = new List<IPortable>(); 
             
            
            

            //for(int items = 0;items < GameObjects.Count; items++)
            //{
            //    Description = GameObjects[items].Description;
            //}
            //Description = GameObjects[0].Description;
        }
    }
}