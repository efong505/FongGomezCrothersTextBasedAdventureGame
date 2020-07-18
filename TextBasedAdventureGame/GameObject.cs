// GameObject.cs
// Programer(s): Edward Fong
// efong@cnmm.edu 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextBasedAdventureGame
{
    public class GameObject
    {
        // Description Property
        /// <summary>
        /// Description Property
        /// </summary>
        public  virtual string Description { get; set; }
        public GameObject(string description) 
        {
            Description = description;
        }

        // GameObject Constructor
        /// <summary>
        /// GameObject Constructor
        /// </summary>
        public GameObject() : this("TBD") { }

        // Overriden ToString()
        /// <summary>
        /// Overriden ToString()
        /// </summary>
        /// <returns>Returns Description</returns>
        public override string ToString()
        {
            return Description;
        }
    }
}
