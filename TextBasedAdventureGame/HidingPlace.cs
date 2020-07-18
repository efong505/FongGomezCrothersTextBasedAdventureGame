using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBasedAdventureGame
{
    public class HidingPlace : GameObject, IHidingPlace
    {
        // Constructor
        /// <summary>
        /// Consstructor
        /// </summary>
        /// <param name="description">The Description of the object</param>
        public HidingPlace(string description) : base(description)
        {
            Description = description;
            
        }

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