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
using System.Windows.Media.TextFormatting;

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
            Locations = new List<MapLocation>();

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
            Locations[9].TravelOptions.Add(new TravelOption("Walk back to Manhattan", Locations[8]));

            #endregion

            #region Objects
            // 0.) In front of CNM Sign - 0
            InventoryItem brochure = new InventoryItem("New York Travel Brochure");
            brochure.Size = 1;
            PortableHidingPlace rock = new PortableHidingPlace("Hollow Rock",1,
                new InventoryItem("Key"));
            Locations[0].Items.Add(rock);
            Locations[0].Items.Add(brochure);


            // 1.) - At Sandiego Pier 
            InventoryItem LrgRock = new InventoryItem("Large Rock");
            LrgRock.Size = 20; // Set to higher than max so cannot be moved
            HidingPlace SeaShell  = new HidingPlace("Sea Shell");
            SeaShell.HiddenObject = new InventoryItem("Gold Coin");
            // Add objects to List
            Locations[1].Items.Add(LrgRock);
            Locations[1].Items.Add(SeaShell);

            // 2.) - In Honolulu Boat Harbor in front of Aloha Tower 
            PortableHidingPlace Purse = new PortableHidingPlace("Purse",1,new InventoryItem("Knife"));
            InventoryItem Shell = new InventoryItem("Conch Shell");
            InventoryItem Crab = new InventoryItem("Crab");

            Locations[2].Items.Add(Purse);
            Locations[2].Items.Add(Shell);
            Locations[2].Items.Add(Crab);

            // 3.) Standing in front of Makua Cave
            PortableHidingPlace MetalBox = new PortableHidingPlace("MetalBox",
                2,new InventoryItem("Bone"));
            InventoryItem Chip = new InventoryItem("Bellagio Casino Chip");
            InventoryItem crab = new InventoryItem("Crab");
            
            Locations[3].Items.Add(MetalBox);
            Locations[3].Items.Add(crab);
            Locations[3].Items.Add(Chip);

            // 4.) In Makua Cave
            HidingPlace TikiStatue = new HidingPlace("Tiki Statue"); 
            TikiStatue.HiddenObject = new InventoryItem("Large Rare Diamond");
            InventoryItem LargeCrab = new InventoryItem("A Larger Crab");
            LargeCrab.Size = 2;
            InventoryItem shell = new InventoryItem("Conch Shell");
            
            Locations[4].Items.Add(TikiStatue);
            Locations[4].Items.Add(shell);
            Locations[4].Items.Add(LargeCrab);

            // 5.) Deeper in Makua Cave
            Locations[5].Items.Add(new PortableHidingPlace("Lunch Box", 2, new InventoryItem("Can of Tuna")));
            InventoryItem flashlight = new InventoryItem("Old Flashlight");
            InventoryItem Skeleto = new InventoryItem("Human Skeleton"); // Not portable
            Skeleto.Size = 20;
            InventoryItem crab2 = new InventoryItem("Crab");
            
            Locations[5].Items.Add(flashlight);
            Locations[5].Items.Add(Skeleto);
            Locations[5].Items.Add(crab2);

            // 6.) Albuquerque International Airport
            PortableHidingPlace Wallet = new PortableHidingPlace("Wallet",1,
                new InventoryItem("$500 Cash"));
            InventoryItem Coin = new InventoryItem("Egyptian Coin");
            InventoryItem trash = new InventoryItem("Crumbled Piece of Paper");
            
            
            Locations[6].Items.Add(Wallet);
            Locations[6].Items.Add(Coin);
            Locations[6].Items.Add(trash);

            // 7.) JFK International Airport
            PortableHidingPlace Watch = new PortableHidingPlace(
                "Watch", 1, new InventoryItem("A USB drive"));
            InventoryItem ticket = new InventoryItem("Old Plane Ticket");
            InventoryItem photo = new InventoryItem("Old Photo");
            Locations[7].Items.Add(Watch);
            Locations[7].Items.Add(ticket);
            Locations[7].Items.Add(photo);

            // 8.) In Manhattan   
            InventoryItem Pen = new InventoryItem("Pen");
            InventoryItem tickets = new InventoryItem("2 Broadway Play Tickets");
            PortableHidingPlace Bottle = new PortableHidingPlace("Message in a Coke Bottle", 2,
                new InventoryItem("Letter to Julia"));
            InventoryItem helmet = new InventoryItem("a homeade metal helmet full of holes with 'Ned Kelly' engraved");
            
            Locations[8].Items.Add(Pen);
            Locations[8].Items.Add(tickets);
            Locations[8].Items.Add(Bottle);
            Locations[8].Items.Add(helmet);

            // 9.) Touring Manhattan
            HidingPlace Boulder = new HidingPlace("Boulder");
            Boulder.HiddenObject = new InventoryItem("I Love New York Keychain");
            InventoryItem map = new InventoryItem("Treasure Map");
            InventoryItem shovel = new InventoryItem("Collapsible Shovel");
            shovel.Size = 4;
            
            Locations[9].Items.Add(Boulder);
            Locations[9].Items.Add(map);
            Locations[9].Items.Add(shovel);

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
