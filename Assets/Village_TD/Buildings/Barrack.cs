using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Village_TD
{
    class Barrack:Building
    {
        private int numSwordfighters;   //number of swordfighters created and alive
        private int numArchers;         // " " archers "
        private int numKnights;         // " " knights "
        private int totalStrength;      //total strength of the current troops
        private int numOfUniqueTroops = 3;
        private int defaultStartValue = 0;  //default start value used in start() method to (re)set values to 0

        public Text totalStrengthText;  //text variables to display in unity
        public Text numSwordfightersText;
        public Text numArchersText;
        public Text numKnightsText;
        public Text swordfightersCost;
        public Text archersCost;
        public Text knightsCost;
        public Button createSwordfighters;
        public Button createArchers;
        public Button createKnights;

        private readonly int[] swordfighterCost = { 45, 70, 25 }; //element 0 = clay, element 1 = iron, element 2 = wood
        private readonly int[] archerCost = { 70, 100, 150 };
        private readonly int[] knightCost = { 200, 350, 250 };

        public GameObject InputSwordFighter;    //inputfields for creating of troops
        public GameObject InputArcher;
        public GameObject InputKnight;

        private string numberToCreateSwordfighters; //text given back from the inputfields
        private string numberToCreateArchers;
        private string numberToCreateKnights;

        int numberOfClay;   //local 'temporary' storage for the number of resources
        int numberOfIron;
        int numberOfWood;

        new void Start()    //called at start of the game
        {
            base.Start();
            NumSwordfighters = defaultStartValue;
            NumArchers = defaultStartValue;
            NumKnights = defaultStartValue;
            setArchersCostText();
            setKnightsCostText();
            setSwordfightersCostText();
            unlockCombatant();
            totalStrength = defaultStartValue;
        }

        new void upgrade()  //calles when the upgradebutton for barrack is pressed
        {
            base.upgrade();
            unlockCombatant();
        }

        public override int maxLevel()
        {
            return numOfUniqueTroops;   // sets maxlevel based on number of unique troops
        }

        public int NumSwordfighters //property of numSwordfighters
        {
            get{ return numSwordfighters; }
            set
            {
                numSwordfighters = value;
                setTroopsText();
                setTotalStrength();
            }
        }

        public int NumArchers   //property of numArchers
        {
            get { return numArchers; }
            set
            {
                numArchers = value;
                setTroopsText();
                setTotalStrength();
            }
        }

        public int NumKnights //property of numKnights
        {
            get { return numKnights; }
            set
            {
                numKnights = value;
                setTroopsText();
                setTotalStrength();
            }
        }

        public int TotalStrength //property of totalStrength
        {
            get
            {
                return totalStrength;
            }

            set
            {
                totalStrength = value;
            }
        }

        public void setTotalStrength()  //method to calculate the total strength of the amount of troops and update the text in unity
        {
            TotalStrength = (NumSwordfighters * GameObject.Find("Wall").GetComponent<Wall>().SwordfighterStrength + NumArchers * GameObject.Find("Wall").GetComponent<Wall>().ArcherStrength + NumKnights * GameObject.Find("Wall").GetComponent<Wall>().KnightStrength);
            totalStrengthText.text = "Total strength of troops: " + TotalStrength.ToString();
        }

    void unlockCombatant()  //enables the button so next combatant is unlocked at next level
        {
            if(Level==3)
            {
                createKnights.interactable = true;
                
            }

            else if(Level==2)
            {
                
                createArchers.interactable = true;
                
            }
            else if(Level==1)
            {
                createKnights.interactable = false;
                createArchers.interactable = false;
                
            }
        }

        void setTroopsText()    //method to set the number of troops text in unity
        {
            numSwordfightersText.text = NumSwordfighters.ToString();
            numArchersText.text = NumArchers.ToString();
            numKnightsText.text = NumKnights.ToString();
        }

        public void createSwordfighter() //method to check if the requirements are met to create a certain amount of swordfighters and creates them
        {
            getResources();
            if (numberOfClay >= (swordfighterCost[0] * Convert.ToInt32(numberToCreateSwordfighters)) && numberOfIron >= (swordfighterCost[1] * Convert.ToInt32(numberToCreateSwordfighters)) && numberOfWood >= (swordfighterCost[2] * Convert.ToInt32(numberToCreateSwordfighters))
                && GameObject.Find("House").GetComponent<House>().MaxPopulation >= GameObject.Find("House").GetComponent<House>().NumPopulation + Convert.ToInt32(numberToCreateSwordfighters) * GameObject.Find("House").GetComponent<House>().swordfighterPopulationFactor)
            {
                NumSwordfighters += Convert.ToInt32(numberToCreateSwordfighters);
                GameObject.Find("ClayPit").GetComponent<ClayPit>().NumberOfResource -= (swordfighterCost[0] * Convert.ToInt32(numberToCreateSwordfighters));
                GameObject.Find("IronMine").GetComponent<IronMine>().NumberOfResource -= (swordfighterCost[1] * Convert.ToInt32(numberToCreateSwordfighters));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (swordfighterCost[2] * Convert.ToInt32(numberToCreateSwordfighters));
                
            }
        }

        public void createArcher() //method to check if the requirements are met to create a certain amount of archers and creates them
        {
            getResources();
            if (numberOfClay >= (archerCost[0] * Convert.ToInt32(numberToCreateArchers)) && numberOfIron >= (archerCost[1] * Convert.ToInt32(numberToCreateArchers)) && numberOfWood >= (archerCost[2] * Convert.ToInt32(numberToCreateArchers))
                 && GameObject.Find("House").GetComponent<House>().MaxPopulation >= GameObject.Find("House").GetComponent<House>().NumPopulation + Convert.ToInt32(numberToCreateArchers) * GameObject.Find("House").GetComponent<House>().archerPopulationFactor)
            {
                NumArchers += Convert.ToInt32(numberToCreateArchers);
                GameObject.Find("ClayPit").GetComponent<ClayPit>().NumberOfResource -= (archerCost[0] * Convert.ToInt32(numberToCreateArchers));
                GameObject.Find("IronMine").GetComponent<IronMine>().NumberOfResource -= (archerCost[1] * Convert.ToInt32(numberToCreateArchers));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (archerCost[2] * Convert.ToInt32(numberToCreateArchers));
            }
        }

        public void createKnight() //method to check if the requirements are met to create a certain amount of knights and creates them
        {
            getResources();
            if (numberOfClay >= (knightCost[0] * Convert.ToInt32(numberToCreateKnights)) && numberOfIron >= (knightCost[1] * Convert.ToInt32(numberToCreateKnights)) && numberOfWood >= (knightCost[2] * Convert.ToInt32(numberToCreateKnights))
                && GameObject.Find("House").GetComponent<House>().MaxPopulation >= GameObject.Find("House").GetComponent<House>().NumPopulation + Convert.ToInt32(numberToCreateKnights) * GameObject.Find("House").GetComponent<House>().knightPopulationFactor)
            {
                NumKnights += Convert.ToInt32(numberToCreateKnights);
                GameObject.Find("ClayPit").GetComponent<ClayPit>().NumberOfResource -= (knightCost[0] * Convert.ToInt32(numberToCreateKnights));
                GameObject.Find("IronMine").GetComponent<IronMine>().NumberOfResource -= (knightCost[1] * Convert.ToInt32(numberToCreateKnights));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (knightCost[2] * Convert.ToInt32(numberToCreateKnights));
            }
        }

        public void inputFieldSwordFighters()   // 3 methods that get called on value change of their inputfield that they're assigned to
        {                                       // the method updates the number to create a certain troop so it can be used to create them
            numberToCreateSwordfighters = InputSwordFighter.GetComponent<InputField>().text;
        }

        public void inputFieldArchers()
        {
            numberToCreateArchers = InputArcher.GetComponent<InputField>().text;
        }

        public void inputFieldKnights()
        {
            numberToCreateKnights = InputKnight.GetComponent<InputField>().text;
        }

        void getResources() //gets the current amount of resources to be used in the create'combatant' method
        {
            numberOfClay = GameObject.Find("ClayPit").GetComponent<ClayPit>().NumberOfResource; //calls for the variable NumberOfResource 
            numberOfIron = GameObject.Find("IronMine").GetComponent<IronMine>().NumberOfResource;
            numberOfWood = GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource;
        }

        public void setSwordfightersCostText()  //3 similar methods to update the cost text to create troops dependable on the input
        {
            if(Convert.ToInt32(numberToCreateSwordfighters)>0)
            {
                swordfightersCost.text = "Clay[" + (Convert.ToInt32(numberToCreateSwordfighters) * swordfighterCost[0]) + "]\tIron[" + (Convert.ToInt32(numberToCreateSwordfighters) * swordfighterCost[1]) + "]\tWood[" + (Convert.ToInt32(numberToCreateSwordfighters) * swordfighterCost[2]) + "]";

            }
            else
            {
                swordfightersCost.text = "Clay[" + swordfighterCost[0] + "]\tIron[" + swordfighterCost[1] + "]\tWood[" + swordfighterCost[2] + "]";
            }
        }

        public void setArchersCostText()
        {
            if (Convert.ToInt32(numberToCreateArchers) > 0)
            {
                archersCost.text = "Clay[" + (Convert.ToInt32(numberToCreateArchers) * archerCost[0]) + "]\tIron[" + (Convert.ToInt32(numberToCreateArchers) * archerCost[1]) + "]\tWood[" + (Convert.ToInt32(numberToCreateArchers) * archerCost[2]) + "]";

            }
            else
            {
                archersCost.text = "Clay[" + archerCost[0] + "]\tIron[" + archerCost[1] + "]\tWood[" + archerCost[2] + "]";
            }
        }

        public void setKnightsCostText()
        {
            if (Convert.ToInt32(numberToCreateKnights) > 0)
            {
                knightsCost.text = "Clay[" + (Convert.ToInt32(numberToCreateKnights) * knightCost[0]) + "]\tIron[" + (Convert.ToInt32(numberToCreateKnights) * knightCost[1]) + "]\tWood[" + (Convert.ToInt32(numberToCreateKnights) * knightCost[2]) + "]";

            }
            else
            {
                knightsCost.text = "Clay[" + knightCost[0] + "]\tIron[" + knightCost[1] + "]\tWood[" + knightCost[2] + "]";
            }
        }
    }
}
