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
        public string Description { get; set; }
        public GameObject(string description) 
        {
            Description = description;
        }

        public GameObject() : this("TBD") { }

        public override string ToString()
        {
            return Description;
        }
    }
}
