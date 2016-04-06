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
        private int numSwordfighters;   //temporary value
        private int numArchers;         //temporary value
        private int numKnights;         //temporary value

        public Text numSwordfightersText;
        public Text numArchersText;
        public Text numKnightsText;
        public Text swordfightersCost;
        public Text archersCost;
        public Text knightsCost;


        private readonly int[] swordfighterCost = { 75, 80, 60 }; //element 0 = clay, element 1 = iron, element 2 = wood
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
            }
        }

        public int NumArchers
        {
            get { return numArchers; }
            set
            {
                numArchers = value;
                setTroopsText();
            }
        }

        public int NumKnights
        {
            get { return numKnights; }
            set
            {
                numKnights = value;
                setTroopsText();
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
            if(numberOfClay >= (swordfighterCost[0]* Convert.ToInt32(numberToCreateSwordfighters)) && numberOfIron >= (swordfighterCost[1]* Convert.ToInt32(numberToCreateSwordfighters)) && numberOfWood >= (swordfighterCost[2]* Convert.ToInt32(numberToCreateSwordfighters)))
            {
                NumSwordfighters += Convert.ToInt32(numberToCreateSwordfighters);
                GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource -= (swordfighterCost[0] * Convert.ToInt32(numberToCreateSwordfighters));
                GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource -= (swordfighterCost[1] * Convert.ToInt32(numberToCreateSwordfighters));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (swordfighterCost[2] * Convert.ToInt32(numberToCreateSwordfighters));
            }
            else
            {
                Debug.Log("insufficient resources");
            }
            Debug.Log(NumSwordfighters);
        }

        public void inputFieldSwordFighters()
         {   
            numberToCreateSwordfighters = InputSwordFighter.GetComponent<InputField>().text;
            Debug.Log(numberToCreateSwordfighters);
         }

        public void createArcher()
        {
            getResources();
            if (numberOfClay >= (archerCost[0] * Convert.ToInt32(numberToCreateArchers)) && numberOfIron >= (archerCost[1] * Convert.ToInt32(numberToCreateArchers)) && numberOfWood >= (archerCost[2] * Convert.ToInt32(numberToCreateArchers)))
            {
                NumArchers += Convert.ToInt32(numberToCreateArchers);
                GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource -= (archerCost[0] * Convert.ToInt32(numberToCreateArchers));
                GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource -= (archerCost[1] * Convert.ToInt32(numberToCreateArchers));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (archerCost[2] * Convert.ToInt32(numberToCreateArchers));
            }
            else
            {
                Debug.Log("insufficient resources");
            }
            
           Debug.Log(NumArchers);
        }

        public void inputFieldArchers()
        {
            numberToCreateArchers = InputArcher.GetComponent<InputField>().text;
            Debug.Log(numberToCreateSwordfighters);
        }

        public void createKnight()
        {
            getResources();
            if (numberOfClay >= (knightCost[0] * Convert.ToInt32(numberToCreateKnights)) && numberOfIron >= (knightCost[1] * Convert.ToInt32(numberToCreateKnights)) && numberOfWood >= (knightCost[2] * Convert.ToInt32(numberToCreateKnights)))
            {
                NumKnights += Convert.ToInt32(numberToCreateKnights);
                GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource -= (knightCost[0] * Convert.ToInt32(numberToCreateKnights));
                GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource -= (knightCost[1] * Convert.ToInt32(numberToCreateKnights));
                GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource -= (knightCost[2] * Convert.ToInt32(numberToCreateKnights));
            }
            else
            {
                Debug.Log("insufficient resources");
            }
            Debug.Log(NumKnights);
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

        public void setTroopsCostText()
        {

        }
    }
}
