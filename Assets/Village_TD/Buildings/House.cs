using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class House:Building
    {
        public Text maxPopulationText;
        
        public static readonly int[] maxLevelPopulations = { 25, 50, 100, 200, 350, 500, 700, 950, 1200, 1500 };//array om te bepalen bij welk level, welke maximum populatie telt

        public override int maxLevel()  //maxlevel is defined with the length of the array maxLevelPopulations
        {
            return maxLevelPopulations.Length;
        }

        public int MaxPopulation    //sets the current maxpopulation based on current house level
        {
            get
            {
                return maxLevelPopulations[Level - 1];
            }   
        }

        new void Start()    //method to show the current maxcapacity in unity at the start of the game
        {
            base.Start();   //does what the superclass method Start() does
            maxPopulationText.text = "Maximum population: " + MaxPopulation.ToString();
        }
        new void upgrade()  //method to show the current maxcapacity in unity after an upgrade
        {
            base.upgrade();
            maxPopulationText.text = "Maximum population: " + MaxPopulation.ToString();
        }

    }
}
