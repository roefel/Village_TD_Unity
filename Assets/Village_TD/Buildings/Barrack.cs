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
        private int swordfighters; //temporary
        public string numberToCreateSwordfighters;
        public string numberToCreateArchers;
        public string numberToCreateKnights;
        public override int maxLevel()
        {
            return 3; // The number 3 is dependable on the number of unique type of troops, 1 type is unlocked each level
        }

        public int Swordfighters
        {
            get
            {
                return swordfighters;
            }

            set
            {
                swordfighters = value;
            }
        }


        public void createSwordfighter()
        {

            
        }

        public void createArcher()
        {

        }

        public void createKnight()
        {

        }
    }
}
