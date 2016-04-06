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
        private int[] swordfighterCost = { 75, 80, 60 };
        private int[] archerCost = { 70, 100, 150 };
        private int[] knightCost = { 200, 350, 250 };

        public GameObject InputSwordFighter;
        public GameObject InputArcher;
        public GameObject InputKnight;

        public string numberToCreateSwordfighters;
        public string numberToCreateArchers;
        public string numberToCreateKnights;

        int numberOfClay;
        int numberOfIron;
        int numberOfWood;

        public override int maxLevel()
        {
            return 3; // The number 3 is dependable on the number of unique type of troops, 1 type is unlocked each level
        }

        public int NumSwordfighters
        {
            get{ return numSwordfighters; }
            set{ numSwordfighters = value; }
        }

        public int NumArchers
        {
            get { return numArchers; }
            set { numArchers = value; }
        }

        public int NumKnights
        {
            get { return numKnights; }
            set { numKnights = value; }
        }

        public int[] SwordfighterCost
        {
            get { return swordfighterCost; }
            set { swordfighterCost = value; }
        }

        public int[] ArcherCost
        {
            get { return archerCost; }
            set { archerCost = value; }
        }

        public int[] KnightCost
        {
            get { return knightCost; }
            set { knightCost = value; }
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
            numberOfClay = GameObject.Find("ClayPit").GetComponent<clayPit>().NumberOfResource; //calls for the variable NumberOfResources 
            numberOfIron = GameObject.Find("IronMine").GetComponent<ironMine>().NumberOfResource;
            numberOfWood = GameObject.Find("LumberMill").GetComponent<LumberMill>().NumberOfResource;
        }
    }
}
