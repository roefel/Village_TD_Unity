using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class Wall : Building
    {
        private int swordfighterStrength;   //3 ints that define the combatant's strength (strength stands for how many enemies 1 troop can kill before dying)
        private int archerStrength;
        private int knightStrength;
        private int numSwitchCases = 5;     //num that defines maxlevel based on number switch cases used to set a troops strength. in other words: each case in the switch represents a level. 5 cases means maxlevel has to equal 5

        public Text swordfighterStrengthText;
        public Text archerStrenghtText;
        public Text knightStrenghText;

        public int SwordfighterStrength // property of swordfighterStrength
        {
            get
            {
                return swordfighterStrength;
            }

            set
            {
                swordfighterStrength = value;
            }
        }

        public int ArcherStrength   // property of archerStrength
        {
            get
            {
                return archerStrength;
            }

            set
            {
                archerStrength = value;
            }
        }

        public int KnightStrength   // property of knightStrength
        {
            get
            {
                return knightStrength;
            }

            set
            {
                knightStrength = value;
            }
        }

        public override int maxLevel()  //method to set maxlevel based on variable numSwitchCases
        {
            return numSwitchCases;
        }
        
        new void Start()
        {
            base.Start();
            setTroopsStrength();
            setTroopsStrengthText();
        }

        new void upgrade()
        {
            base.upgrade();
            setTroopsStrength();
            setTroopsStrengthText();
        }

        void setTroopsStrength()    //method to set the troops strength at the start of the game and after an upgrade
        {
            switch (Level)
            {
                case 1:
                    SwordfighterStrength = 1;
                    ArcherStrength = 2;
                    KnightStrength = 3;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();  //method called because total strength will change if strength per combatant is changed
                    break;
                case 2:
                    KnightStrength = 4;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
                case 3:
                    ArcherStrength = 3;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
                case 4:
                    SwordfighterStrength = 2;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
                case 5:
                    KnightStrength = 5;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
            }
        }

        void setTroopsStrengthText()    //method to set text to display current strength per combatant in unity
        {
            swordfighterStrengthText.text = "Swordfighter strength: " + SwordfighterStrength.ToString();
            archerStrenghtText.text = "Archer strength: " + ArcherStrength.ToString();
            knightStrenghText.text = "Knight strength: " + KnightStrength.ToString();
    }
    }
}
