using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

namespace Village_TD
{
    class Barrack:Building
    {
        private int numSwordfighters = 6;   //temporary value
        private int numArchers = 4;         //temporary value
        private int numKnights = 3;         //temporary value
        private int[] swordfighterCost = new int[3];
        private int[] archerCost = new int[3];
        private int[] knightCost = new int[3];

        public string numberToCreateSwordfighters;
        public string numberToCreateArchers;
        public string numberToCreateKnights;
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
            /*
            meObject.Find("Swordfighters").GetComponent<Swordfighter>().amSwordfighters += Convert.ToInt32(numberToCreateSwordfighters);
            Debug.Log(GameObject.Find("Swordfighters").GetComponent<Swordfighter>().amSwordfighters);*/
        }
        
        public void createArcher()
        {
            //ameObject.Find("Archers").GetComponent<Archer>().amArchers += Convert.ToInt32(numberToCreateArchers);

        }

        public void createKnight()
        {
            //meObject.Find("Knights").GetComponent<Knight>().amKnights += Convert.ToInt32(numberToCreateKnights);

        }
    }
}
