// InventoryItem.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBasedAdventureGame
{
    public class InventoryItem : GameObject, IPortable // inherits from GameObject and IPortable Interface
    {
        // Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="description">Description inherited from GameObject</param>
        public InventoryItem(string description):base(description)
        {
            Description = description;
            Size = 1;
        }

        // Size Property
        /// <summary>
        /// Size Property
        /// </summary>
        public int Size { get; set; }
    }
}