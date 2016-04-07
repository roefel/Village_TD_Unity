using System;
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
        public Text levelText; // variable of type text, used in unity to display text
        public Text buttonText;
        public Text resourceCostsText;
        public Button upgradeButton;    //variable of type Button, used for changing the button state in Unity
        
        
        private int initialClayCostForUpgrade = 12;  //initial cost per material. This can be modified individually.
        private int initialIronCostForUpgrade = 9;
        private int initialWoodCostForUpgrade = 10;
        public int initialWorkersPerLevel = 2;
        private int multiplierInitialCost;          //Multiplier that is used to calulate the cost of each material for each level
        public void multiplierInitialCostAlgorythm()
        {

            Double LevelDouble = Convert.ToDouble(Level);  //convert int Level to Double for use in math.pow
            int exponentialMultiplier = System.Convert.ToInt32(Math.Pow(LevelDouble, 2)); //sets the exponantial multiplier of the level to the power of 2(needs to be converted from double to int
            multiplierInitialCost = 5 * exponentialMultiplier; //sets the multiplier for the initial cost to calculate the cost for each level
        }
        int[] resourceCost = new int[3];//element 0=clay, element 1=iron, element 2=wood



        virtual public int maxLevel()   //the maximum level for each building. Virtual so it can be overrided from each building
        {
            return 0;
        }


        protected void Start()
        {
            level = 1;  
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
        void setCostText()
        {
            if(Level<maxLevel())
            {
                resourceCostsText.text = "Clay[" + resourceCost[0].ToString() + "] Iron[" + resourceCost[1] + "] Wood[" + resourceCost[2] + "]";

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
           
            
            
            
            int numberOfClay = GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource; //calls for the variable NumberOfResources so it can be used to check if there are enough resources to upgrade
            int numberOfIron = GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource;
            int numberOfWood = GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource;
            if (numberOfClay>=resourceCost[0] && numberOfIron>= resourceCost[1] && numberOfWood>=resourceCost[2]) //checks each resource for a sufficient amount of given resources 
            {
                GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource -= resourceCost[0]; //substracts used resources to upgrade from NumberOfResources
                GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource -= resourceCost[1];
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
