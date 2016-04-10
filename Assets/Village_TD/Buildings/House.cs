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

        private int numPopulation;
        public static readonly int[] maxLevelPopulations = { 25, 50, 100, 200, 350, 500, 700, 950, 1200, 1500 };//array om te bepalen bij welk level, welke maximum populatie telt
        public Text maxPopulationText;
        public Text currentPopulationText;

        public int swordfighterPopulationFactor = 1;
        public int archerPopulationFactor = 1;
        public int knightPopulationFactor = 2;

        new void Start()
        {
            base.Start();
            setMaxPopulationText();
            setCurrentPopulationText();
        }

        new void upgrade()
        {
            base.upgrade();
            setMaxPopulationText();
        }

        public int NumPopulation
        {
            get { return numPopulation; }
            set { numPopulation = value; }
        }

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

        void setMaxPopulationText() //sets new maxpopulation text after upgrade to display in unity
        {
            maxPopulationText.text = "Maximum population: " + MaxPopulation.ToString();
        }

        public void setCurrentPopulationText()  //sets currentpopulation text after each troop created or lost
        {
            NumPopulation = GameObject.Find("Barrack").GetComponent<Barrack>().NumSwordfighters*swordfighterPopulationFactor + GameObject.Find("Barrack").GetComponent<Barrack>().NumArchers*archerPopulationFactor + GameObject.Find("Barrack").GetComponent<Barrack>().NumKnights*knightPopulationFactor;
            currentPopulationText.text = "Current population: " + NumPopulation.ToString();
        }


    }
}
