// MapLocation.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Represents a location on the map
    /// </summary>
    public class MapLocation 
    {
        /// <summary>
        /// Description of the location that will be shown to player.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// List of travel options which are a link to where you can go from this location.
        /// </summary>
        public List<TravelOption> TravelOptions { get; set; }
 
        public List<GameObject> Items { get; set;}

        public List<HidingPlace> HiddenObjects { get; set; }
        /// <summary>
        /// Single parameter constructor for game location.
        /// </summary>
        /// <param name="description">Description of the location that will be shown to player.</param>
        public MapLocation(string description)
        {
            Description = description;
            TravelOptions = new List<TravelOption>();
            Items = new List<GameObject>();
            HiddenObjects = new List<HidingPlace>();
            
        }

        /// <summary>
        /// Overidden To String method
        /// </summary>
        /// <returns>Returns the Description of the location</returns>
        public override string ToString()
        {
            return Description;
        }
    }
}
