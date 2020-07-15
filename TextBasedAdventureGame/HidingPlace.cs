using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBasedAdventureGame
{
    public class HidingPlace : GameObject, IHidingPlace
    {
        private GameObject hiddenObject;

        public HidingPlace(string description) : base(description)
        {
        }

        public GameObject HiddenObject 
        {
            get => hiddenObject;
            set { hiddenObject = value; }
        }
        // TODO: Need to figure this out - how to return hiddenObject and then set it to null
        public GameObject Search(GameObject hiddenObject)
        {
            HiddenObject = hiddenObject;
            return HiddenObject;

            
        }
    }
}