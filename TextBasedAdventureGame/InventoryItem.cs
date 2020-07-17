// InventoryItem.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBasedAdventureGame
{
    public class InventoryItem : GameObject, IPortable
    {
        public InventoryItem(string description):base(description)
        {
            Description = description;
            Size = 1;
        }

        public int Size { get; set; }
    }
}