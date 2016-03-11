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

        
    }
}
