using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class Wall : DefenseBuilding
    {
        private int swordfighterStrength;
        private int archerStrength;
        private int knightStrength;

        public Text swordfighterStrengthText;
        public Text archerStrenghtText;
        public Text knightStrenghText;

        public int SwordfighterStrength
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

        public int ArcherStrength
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

        public int KnightStrength
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

        public override int maxLevel()
        {
            return 5;
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

        void setTroopsStrength()
        {
            switch (Level)
            {
                case 1:
                    SwordfighterStrength = 1;
                    ArcherStrength = 2;
                    KnightStrength = 3;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
                case 2:
                    SwordfighterStrength = 1;
                    ArcherStrength = 2;
                    KnightStrength = 4;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
                case 3:
                    SwordfighterStrength = 1;
                    ArcherStrength = 3;
                    KnightStrength = 4;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
                case 4:
                    SwordfighterStrength = 2;
                    ArcherStrength = 3;
                    KnightStrength = 4;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
                case 5:
                    SwordfighterStrength = 2;
                    ArcherStrength = 3;
                    KnightStrength = 5;
                    GameObject.Find("Barrack").GetComponent<Barrack>().setTotalStrength();
                    break;
            }
        }

        void setTroopsStrengthText()
        {
            swordfighterStrengthText.text = "Swordfighter strength: " + SwordfighterStrength.ToString();
            archerStrenghtText.text = "Archer strength: " + ArcherStrength.ToString();
            knightStrenghText.text = "Knight strength: " + KnightStrength.ToString();
    }
    }
}
