using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TextBasedAdventureGame
{
    public class PortableHidingPlace : GameObject, IPortable, IHidingPlace
    {
        
        //private int v;
       // private InventoryItem inventoryItem;
        private GameObject hiddenObject;

        // TODO: check to make sure number of parameters for constructor is correct
        public PortableHidingPlace(string description, int size, GameObject inventoryItem) : base(description)
        {
            Description = description;
            Size = size;
            HiddenObject = inventoryItem;
            
        }

        public int Size { get; set ; }
        public GameObject HiddenObject
        {
            get => hiddenObject;
            set { hiddenObject = value; }
        }
        //private GameObject item;

        public GameObject Search(GameObject gameObject)
        {
            GameObject searched;

            searched = HiddenObject;
            HiddenObject = null;
            return searched;
        }
    }
}