using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TextBasedAdventureGame
{
    public class PortableHidingPlace : GameObject, IPortable, IHidingPlace
    {

        // Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="description">Description of object</param>
        /// <param name="size">Size of Object Created</param>
        /// <param name="inventoryItem">Hidden Object</param>
        public PortableHidingPlace(string description, int size, InventoryItem inventoryItem) : base(description)
        {
            Description = description;
            Size = size;
            HiddenObject = inventoryItem;
            
        }
       
        // Size Property
        /// <summary>
        /// Size Property
        /// </summary>
        public int Size { get; set ; }
        
        // Hidden Object Property
        /// <summary>
        /// Hidden Object Property
        /// </summary>
        public GameObject HiddenObject { get; set; }

        // Search Meethod 
        /// <summary>
        /// Search Method
        /// </summary>
        /// <returns>
        /// Returns Hidden Object and then sets HiddenObject to null
        /// </returns>
        public GameObject Search()
        {
            _ = new GameObject("");
            GameObject Temp = HiddenObject;

            HiddenObject = null;

            return Temp;
        }
    }
}