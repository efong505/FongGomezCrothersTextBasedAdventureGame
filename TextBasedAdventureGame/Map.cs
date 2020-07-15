// TravelOption
// Programer: Rob Garner (rgarner7@cnm.edu)
// Date: 25 May 2016
// Represents a travel option.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TextBasedAdventureGame
{
    /// <summary>
    /// Class that represents the game. 
    /// Has a map and location of player.
    /// </summary>
    class Map
    {
        /// <summary>
        /// List of map locations.
        /// </summary>
        public List<MapLocation> Locations { get; set; }

        /// <summary>
        /// Player's location.
        /// </summary>
       public MapLocation PlayerLocation { get; set; }

        /// <summary>
        /// Constructor that creates the game map.
        /// </summary>
        public Map()
        {
            Player player = new Player(PlayerLocation);
            player.AddInventoryItem(new InventoryItem("Claw"));
            //Create map locations first
            Locations = new List<MapLocation>();
            HidingPlace rock = new HidingPlace("Large Rock");
            rock.HiddenObject = new InventoryItem("Snow Globe");


            //Locations[0].Items.Add(new InventoryItem("Brocken Rifle"));
            //Locations[1].Items.Add(new PortableHidingPlace("Backpack", 1, new InventoryItem("Peanut Butter and " +
            //    "Jelly Sandwich")));

            Locations.Add(new MapLocation("You are on a road leading to a town.")); // location 0
            Locations.Add(new MapLocation("You are on a road in front of a saloon.")); // location 1
            Locations.Add(new MapLocation("You are in a saloon.")); // location 2
            Locations.Add(new MapLocation("You are on a road in front of a jail."));// location 3
            Locations.Add(new MapLocation("You are in a jail.")); // location 4
            Locations.Add(new MapLocation("You are on a road in front of a general store."));// location 5
            Locations.Add(new MapLocation("You are in a general store.")); // location 6

            
            //Now add travel options to each map location
            
            //Road outside town - 0
            Locations[0].TravelOptions.Add(new TravelOption("A town is to the west of you.",Locations[1]));

            //Road in front of salloon - 1
            Locations[1].TravelOptions.Add(new TravelOption("The road out of town is to the east of you.", Locations[0]));            
            Locations[1].TravelOptions.Add(new TravelOption("A salloon is to the north of you.", Locations[2]));            
            Locations[1].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[3]));

            //Salloon -2
            Locations[2].TravelOptions.Add(new TravelOption("The saloon door leads out to the street.", Locations[1]));

            //Road in front of jail - 3
            Locations[3].TravelOptions.Add(new TravelOption("A road is to the east of you.", Locations[1]));
            Locations[3].TravelOptions.Add(new TravelOption("A jail is to the north of you.", Locations[4]));
            Locations[3].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[5]));

            //Jail - 4
            Locations[4].TravelOptions.Add(new TravelOption("The jail door leads out to the street.", Locations[3]));

            //Road in front of general store -5
            Locations[5].TravelOptions.Add(new TravelOption("A road is to the east of you.", Locations[3]));
            Locations[5].TravelOptions.Add(new TravelOption("A general store is to the north of you.", Locations[6]));

            //Jail - 6
            Locations[6].TravelOptions.Add(new TravelOption("The store door leads out to the street.", Locations[5]));


            //Set the player's starting location.
            PlayerLocation = Locations[0];
        }

    }
}
