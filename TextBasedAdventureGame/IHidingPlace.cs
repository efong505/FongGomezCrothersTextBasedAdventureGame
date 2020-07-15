using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBasedAdventureGame
{
    interface IHidingPlace
    {
        GameObject  HiddenObject { get; set; }
        GameObject Search(GameObject hiddenObject);
    }

}