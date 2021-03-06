﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace Village_TD
{
    class Building:MonoBehaviour
    {
        private int level; //int level for each building, start level=1
        private int defaultStartLevel = 1; //default start level to (re)set level to 1 at start of the game

        public Text levelText;          // variable of type text, used in unity to display text. Used to display current level
        public Text buttonText;         // variable used to update upgrade buttons texts if max level is reached
        public Text resourceCostsText;  // variable used to update current resource cost text for next uprade
        public Button upgradeButton;    // variable of type Button, used for changing the button state in Unity
        
        
        private int initialClayCostForUpgrade = 44;  //initial cost per material. This can be modified individually to modify game difficulty.
        private int initialIronCostForUpgrade = 32;
        private int initialWoodCostForUpgrade = 36;
        private Double mathPower = 2;        
        private int multiplierInitialCost;          //Multiplier that is used to calulate the cost of each material for each level
        public void multiplierInitialCostAlgorythm()
        {
            Double LevelDouble = Convert.ToDouble(Level);  //convert int Level to Double for use in math.pow
            multiplierInitialCost = System.Convert.ToInt32(Math.Pow(LevelDouble, mathPower)); //sets the exponantial multiplier of the level to the power of 2. used to calculate resourcecost for each level(needs to be converted from double to int)
        }

        int[] resourceCost = new int[3];//element 0=clay, element 1=iron, element 2=wood

        virtual public int maxLevel()   //the maximum level for each building. Virtual so it can be overrided from each building
        {
            return 0;
        }


        protected void Start()
        {
            level = defaultStartLevel;  
            setLevelText();
            setResourceCost();
        }


        void setLevelText()     //method to set the current int level to display into unity
        {
            levelText.text = "level: " + level.ToString();
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
                setLevelText();     //if the value of level changes. the display in unity has to be updated
                updateButton();     //checks if the building has reached max level( if so it disables the button)
            }

        }
        void setCostText()          //sets current resourcecosts texts after a level upgrade
        {
            if(Level<maxLevel())
            {
                resourceCostsText.text = "Clay[" + resourceCost[0].ToString() + "]\tIron[" + resourceCost[1] + "]\tWood[" + resourceCost[2] + "]";

            }
            else
            {
                resourceCostsText.text = "Maximum Level Reached";
            }
        }

        void setResourceCost()
        {
            multiplierInitialCostAlgorythm();   //calls to calculate the multiplier for the building level
            resourceCost[0] = initialClayCostForUpgrade * multiplierInitialCost;    //calculates the cost of each resource
            resourceCost[1] = initialIronCostForUpgrade * multiplierInitialCost;
            resourceCost[2] = initialWoodCostForUpgrade * multiplierInitialCost;
            setCostText();
        }

         public void upgrade()    //method to upgrade a building
        {
           
            
            
            
            int numberOfClay = GameObject.Find("ClayPit").GetComponent<ClayPit>().NumberOfResource; //calls for the variable NumberOfResources so it can be used to check if there are enough resources to upgrade
            int numberOfIron = GameObject.Find("IronMine").GetComponent<IronMine>().NumberOfResource;
            int numberOfWood = GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource;
            if (numberOfClay>=resourceCost[0] && numberOfIron>= resourceCost[1] && numberOfWood>=resourceCost[2]) //checks each resource for a sufficient amount of given resources 
            {
                GameObject.Find("ClayPit").GetComponent<ClayPit>().NumberOfResource -= resourceCost[0]; //substracts used resources to upgrade from NumberOfResources
                GameObject.Find("IronMine").GetComponent<IronMine>().NumberOfResource -= resourceCost[1];
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= resourceCost[2];
                Level ++;
                setResourceCost();

            }

        }
        
        void updateButton() //method to disable button  if max level is reached for a building
        {
            if (Level >= maxLevel())
            {
                upgradeButton.interactable = false;
                buttonText.text = "Max Lvl";
               
            }

        }
    }
}
