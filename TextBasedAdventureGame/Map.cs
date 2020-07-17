// Map.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 
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
            //if(player.AddInventoryItem()
            // player.AddInventoryItem(new GameObject("Testing"));
            //player.AddInventoryItem(new GameObject("restst"));
           // player.AddInventoryItem(new InventoryItem("Claw"));
            //Create map locations first
            Locations = new List<MapLocation>();



            //Locations[1].Items.Add(new PortableHidingPlace("Backpack", 1, new InventoryItem("Peanut butter and jelly sandwich")));
            #region Old Locations
            /* // Original Locations
             Locations.Add(new MapLocation("You are on a road leading to a town.")); // location 0
             Locations.Add(new MapLocation("You are on a road in front of a saloon.")); // location 1
             Locations.Add(new MapLocation("You are in a saloon.")); // location 2
             Locations.Add(new MapLocation("You are on a road in front of a jail."));// location 3
             Locations.Add(new MapLocation("You are in a jail.")); // location 4
             Locations.Add(new MapLocation("You are on a road in front of a general store."));// location 5
             Locations.Add(new MapLocation("You are in a general store.")); // location 6
            */
            #endregion

            #region New Locations
            //TODO: New Locations
            Locations.Add(new MapLocation("You are at CNM in front of a sign that says this way to Hawaii.")); // location 0
            Locations.Add(new MapLocation("You Are at the San Diego Pier")); // location 1
            Locations.Add(new MapLocation("You are standing in front of Aloha Tower with the cruise ship behind you")); // location 2
            Locations.Add(new MapLocation("You are standing in front of Makua Cave, an ancient 100ft. tall, 450ft. deep cave")); // location 3
            Locations.Add(new MapLocation("You are in Makua Cave"));// location 4
            Locations.Add(new MapLocation("You are deeper into Cave."));// location 5
            Locations.Add(new MapLocation("You are at the Albuquerque International Airport")); // location 6
            Locations.Add(new MapLocation("You are at the JFK International Airport in New York")); // location 7
            Locations.Add(new MapLocation("You are in Manhattan, New York"));// location 8
            Locations.Add(new MapLocation("You are Touring the Statue of Liberty, Central Park and the Empire State Building")); // location 9
            #endregion

            #region New Travel Options
            //Now add travel options to each map location

            //In front of CNM Sign - 0
            Locations[0].TravelOptions.Add(new TravelOption("Jump in your car and drive west to San Diego Pier.", Locations[1]));
            Locations[0].TravelOptions.Add(new TravelOption("Take an Uber to the airport ", Locations[6]));

            //At Sandiego Pier - 1
            Locations[1].TravelOptions.Add(new TravelOption("Take a cruise ship to Honolulu Pier #2", Locations[2]));
            Locations[1].TravelOptions.Add(new TravelOption("Jump in your car and drive east towards CNM Albuquerque, NM", Locations[0]));

            //In Honolulu Boat Harbor in front of Aloha Tower -2
            Locations[2].TravelOptions.Add(new TravelOption("A road from Honolulu leading west towards cave", Locations[3]));
            Locations[2].TravelOptions.Add(new TravelOption("A Cruise back to San Diego Pier", Locations[1]));

            //Standing in front of Makua Cave - 3
            Locations[3].TravelOptions.Add(new TravelOption("Walk into cave", Locations[4]));
            Locations[3].TravelOptions.Add(new TravelOption("A road going east back to the Honolulu Pier #2", Locations[2]));

            //In Makua Cave- 4
            Locations[4].TravelOptions.Add(new TravelOption("Exit the cave", Locations[3]));
            Locations[4].TravelOptions.Add(new TravelOption("Walk deeper into the cave", Locations[5]));

            //Deeper in Makua Cave - 5
            Locations[5].TravelOptions.Add(new TravelOption("Walk back out towards the entrance of cave.", Locations[4]));
           
            //Albuquerque International Airport-6
            Locations[6].TravelOptions.Add(new TravelOption("Uber back to CNM.", Locations[0]));
            Locations[6].TravelOptions.Add(new TravelOption("Take a flight to New York", Locations[7]));

            //JFK International Airport - 7
            Locations[7].TravelOptions.Add(new TravelOption("Take flight to Albuquerque International Airport", Locations[6]));
            Locations[7].TravelOptions.Add(new TravelOption("Take AirTrain to subway to Manhattan", Locations[8]));
            
            //In Manhattan- 8
            Locations[8].TravelOptions.Add(new TravelOption("Take subway back to JFK International Airport", Locations[7]));
            Locations[8].TravelOptions.Add(new TravelOption("Take a tour to see the Statue of Liberty, Central Park, and the Empires State Building.", Locations[9]));

            //Touring Manhattan- 9
            Locations[9].TravelOptions.Add(new TravelOption("Walk back to subway and take subway back to JFK International Airport", Locations[7]));

            #endregion

            #region Objects
            // objects
            //Locations[0].Items.Add(new InventoryItem("Token"));
            //Locations[0].Items.Add(new InventoryItem("Brocken Rifle"));
            //Locations[0].Items.Add(new HidingPlace("Ammo"));
            //Locations[0].HiddenObjects.Add(new GameObject("GunPowder"));
            //Locations[1].Items.Add(new PortableHidingPlace("Backpack", 1, new GameObject("Peanut Butter and " +
            //    "Jelly Sandwich")));
            HidingPlace rock = new HidingPlace("Large Rock");
            rock.HiddenObject = new GameObject("Snow Globe");
            Locations[0].Items.Add(rock);
            Locations[2].Items.Add(new GameObject("Broken Chair"));
            Locations[2].Items.Add(new HidingPlace("Chair"));
            Locations[2].HiddenObjects.Add(new GameObject("Snake"));


            #endregion
            #region  Old Travel Options
            ////Now add travel options to each map location

            ////Road outside town - 0
            //Locations[0].TravelOptions.Add(new TravelOption("A town is to the west of you.", Locations[1]));

            ////Road in front of salloon - 1
            //Locations[1].TravelOptions.Add(new TravelOption("The road out of town is to the east of you.", Locations[0]));
            //Locations[1].TravelOptions.Add(new TravelOption("A salloon is to the north of you.", Locations[2]));
            //Locations[1].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[3]));

            ////Salloon -2
            //Locations[2].TravelOptions.Add(new TravelOption("The saloon door leads out to the street.", Locations[1]));

            ////Road in front of jail - 3
            //Locations[3].TravelOptions.Add(new TravelOption("A road is to the east of you.", Locations[1]));
            //Locations[3].TravelOptions.Add(new TravelOption("A jail is to the north of you.", Locations[4]));
            //Locations[3].TravelOptions.Add(new TravelOption("A road leading further into town is to the west of you.", Locations[5]));

            ////Jail - 4
            //Locations[4].TravelOptions.Add(new TravelOption("The jail door leads out to the street.", Locations[3]));

            ////Road in front of general store -5
            //Locations[5].TravelOptions.Add(new TravelOption("A road is to the east of you.", Locations[3]));
            //Locations[5].TravelOptions.Add(new TravelOption("A general store is to the north of you.", Locations[6]));

            ////Jail - 6
            //Locations[6].TravelOptions.Add(new TravelOption("The store door leads out to the street.", Locations[5]));

            #endregion

            //Set the player's starting location.
            PlayerLocation = Locations[0];
        }

    }
}
