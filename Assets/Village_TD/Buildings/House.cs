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
        //private int numWorkers;
        private int numPopulation;
        public static readonly int[] maxLevelPopulations = { 25, 50, 100, 200, 350, 500, 700, 950, 1200, 1500 };//array om te bepalen bij welk level, welke maximum populatie telt
        public Text maxPopulationText;
        public Text currentPopulationText;

        public int swordfighterPopulationFactor = 1;
        public int archerPopulationFactor = 1;
        public int knightPopulationFactor = 2;
        //public int NumWorkers
        //{
        //    get { return numWorkers; }
        //    set { numWorkers = value; }
        //}

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

        void setMaxPopulationText()
        {
            maxPopulationText.text = "Maximum population: " + MaxPopulation.ToString();
        }

        //void setNumWorkers()
        //{
        //    /*
        //    //aantal werknemers van elk gebouw ophalen, ergens in het project
        //    AmWorkers = GameObject.Find("workers").GetComponent<Barrack>().initialWorkersPerLevel   //aantal werknemers per level van een kazerne
        //    + GameObject.Find("workers").GetComponent<House>().initialWorkersPerLevel               //aantal werknemers per level van een huis
        //    + GameObject.Find("workers").GetComponent<Warehouse>().initialWorkersPerLevel           //aantal werknemers per level van de opslagplaats
        //    + GameObject.Find("workers").GetComponent<clayPit>().initialWorkersPerLevel             //aantal werknemers per level van een clay
        //    + GameObject.Find("workers").GetComponent<ironMine>().initialWorkersPerLevel            //aantal werknemers per level van een iron
        //    + GameObject.Find("workers").GetComponent<LumberMill>().initialWorkersPerLevel;         //aantal werknemers per level van een wood
        //    */
        //}

        public void setCurrentPopulationText()
        {
            NumPopulation = GameObject.Find("Barrack").GetComponent<Barrack>().NumSwordfighters*swordfighterPopulationFactor + GameObject.Find("Barrack").GetComponent<Barrack>().NumArchers*archerPopulationFactor + GameObject.Find("Barrack").GetComponent<Barrack>().NumKnights*knightPopulationFactor;
            currentPopulationText.text = "Current population: " + NumPopulation.ToString();
        }


    }
}
