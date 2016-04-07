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
        private int numSwordfighters;  
        private int numArchers;         
        private int numKnights;
        private int totalStrength;

        public Text totalStrengthText;
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

        public GameObject InputSwordFighter;
        public GameObject InputArcher;
        public GameObject InputKnight;

        private string numberToCreateSwordfighters;
        private string numberToCreateArchers;
        private string numberToCreateKnights;

        int numberOfClay;
        int numberOfIron;
        int numberOfWood;

        new void Start()
        {
            base.Start();
            NumSwordfighters = 0;
            NumArchers = 0;
            NumKnights = 0;
            setArchersCostText();
            setKnightsCostText();
            setSwordfightersCostText();
            unlockCombatant();
            totalStrength = 0;
        }

        new void upgrade()
        {
            base.upgrade();
            unlockCombatant();
        }

        public override int maxLevel()
        {
            return 3; // The number 3 is dependable on the number of unique type of troops, 1 type is unlocked each level
        }

        public int NumSwordfighters
        {
            get{ return numSwordfighters; }
            set
            {
                numSwordfighters = value;
                setTroopsText();
                setTotalStrength();
            }
        }

        public int NumArchers
        {
            get { return numArchers; }
            set
            {
                numArchers = value;
                setTroopsText();
                setTotalStrength();
            }
        }

        public int NumKnights
        {
            get { return numKnights; }
            set
            {
                numKnights = value;
                setTroopsText();
                setTotalStrength();
            }
        }

        public int TotalStrength
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

        public void setTotalStrength()
        {
            TotalStrength = (NumSwordfighters * GameObject.Find("Wall").GetComponent<Wall>().SwordfighterStrength + NumArchers * GameObject.Find("Wall").GetComponent<Wall>().ArcherStrength + NumKnights * GameObject.Find("Wall").GetComponent<Wall>().KnightStrength);
            totalStrengthText.text = "Total strength of troops: " + TotalStrength.ToString();
        }

    void unlockCombatant()
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

        void setTroopsText()
        {
            numSwordfightersText.text = NumSwordfighters.ToString();
            numArchersText.text = NumArchers.ToString();
            numKnightsText.text = NumKnights.ToString();
        }

        public void createSwordfighter()
        {
            getResources();
            if (numberOfClay >= (swordfighterCost[0] * Convert.ToInt32(numberToCreateSwordfighters)) && numberOfIron >= (swordfighterCost[1] * Convert.ToInt32(numberToCreateSwordfighters)) && numberOfWood >= (swordfighterCost[2] * Convert.ToInt32(numberToCreateSwordfighters))
                && GameObject.Find("House").GetComponent<House>().MaxPopulation >= GameObject.Find("House").GetComponent<House>().NumPopulation + Convert.ToInt32(numberToCreateSwordfighters) * GameObject.Find("House").GetComponent<House>().swordfighterPopulationFactor)
            {
                NumSwordfighters += Convert.ToInt32(numberToCreateSwordfighters);
                GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource -= (swordfighterCost[0] * Convert.ToInt32(numberToCreateSwordfighters));
                GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource -= (swordfighterCost[1] * Convert.ToInt32(numberToCreateSwordfighters));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (swordfighterCost[2] * Convert.ToInt32(numberToCreateSwordfighters));
                
            }
            else
            {
                Debug.Log("create of troops failed");
            }
        }

        public void createArcher()
        {
            getResources();
            if (numberOfClay >= (archerCost[0] * Convert.ToInt32(numberToCreateArchers)) && numberOfIron >= (archerCost[1] * Convert.ToInt32(numberToCreateArchers)) && numberOfWood >= (archerCost[2] * Convert.ToInt32(numberToCreateArchers))
                 && GameObject.Find("House").GetComponent<House>().MaxPopulation >= GameObject.Find("House").GetComponent<House>().NumPopulation + Convert.ToInt32(numberToCreateArchers) * GameObject.Find("House").GetComponent<House>().archerPopulationFactor)
            {
                NumArchers += Convert.ToInt32(numberToCreateArchers);
                GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource -= (archerCost[0] * Convert.ToInt32(numberToCreateArchers));
                GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource -= (archerCost[1] * Convert.ToInt32(numberToCreateArchers));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (archerCost[2] * Convert.ToInt32(numberToCreateArchers));
            }
        }

        public void createKnight()
        {
            getResources();
            if (numberOfClay >= (knightCost[0] * Convert.ToInt32(numberToCreateKnights)) && numberOfIron >= (knightCost[1] * Convert.ToInt32(numberToCreateKnights)) && numberOfWood >= (knightCost[2] * Convert.ToInt32(numberToCreateKnights))
                && GameObject.Find("House").GetComponent<House>().MaxPopulation >= GameObject.Find("House").GetComponent<House>().NumPopulation + Convert.ToInt32(numberToCreateKnights) * GameObject.Find("House").GetComponent<House>().knightPopulationFactor)
            {
                NumKnights += Convert.ToInt32(numberToCreateKnights);
                GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource -= (knightCost[0] * Convert.ToInt32(numberToCreateKnights));
                GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource -= (knightCost[1] * Convert.ToInt32(numberToCreateKnights));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (knightCost[2] * Convert.ToInt32(numberToCreateKnights));
            }
        }

        public void inputFieldSwordFighters()
        {
            numberToCreateSwordfighters = InputSwordFighter.GetComponent<InputField>().text;
            Debug.Log(numberToCreateSwordfighters);
        }

        public void inputFieldArchers()
        {
            numberToCreateArchers = InputArcher.GetComponent<InputField>().text;
            Debug.Log(numberToCreateSwordfighters);
        }

        public void inputFieldKnights()
        {
            numberToCreateKnights = InputKnight.GetComponent<InputField>().text;
            Debug.Log(numberToCreateKnights);
        }

        void getResources()
        {
            numberOfClay = GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource; //calls for the variable NumberOfResource 
            numberOfIron = GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource;
            numberOfWood = GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource;
        }

        public void setSwordfightersCostText()
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
