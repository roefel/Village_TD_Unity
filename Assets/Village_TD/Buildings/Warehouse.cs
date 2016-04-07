using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
namespace Village_TD
{
    class Warehouse:Building
    {

        public static readonly int[] maxLevelStorage = { 300, 1200, 4800, 9600, 20000, 30000};//array for defining max warehouse capacity per level

        public override int maxLevel() // maxLevel is defined with the lenght of the array maxLevelStorage
        {
            return maxLevelStorage.Length;
        }

        public Text maxCapacity; //variable of type text to show the current maxcapacity of the warehouse in unity
        public int MaxStorage    //sets the current maxstorage based on level
        {
            get
            {
                return maxLevelStorage[Level - 1];
            }
        }
        new void Start()    //method to show the current maxcapacity in unity at the start of the game
        {
            base.Start();   //does what the superclass method Start() does
            maxCapacity.text = "Maximum storage capacity: " + MaxStorage.ToString();  
        }
        new void upgrade()  //method to show the current maxcapacity in unity after an upgrade
        {
            base.upgrade();
            maxCapacity.text = "Maximum storage capacity: " + MaxStorage.ToString();
        }
        
        
    }
}
