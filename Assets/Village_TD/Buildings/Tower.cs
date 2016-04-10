using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class Tower : Building
    {
        readonly int[] troopsKilledPerLevel = { 1, 2, 4, 7, 10, 23, 56, 86, 123, 200 }; //array to both define maxlevel and number of troops the tower kills before taken into attack calculation
        private int troopsKilled;   //variable used for the current troops the tower kills 

        public Text troopsKilledText;   //text variable to display how many troops the tower kills in unity

        public override int maxLevel()  //method to set maxlevel based on troopsKilledPerLevel's length
        {
            return troopsKilledPerLevel.Length;

        }

        public int TroopsKilled //property of troopsKilled
        {
            get
            {
                return troopsKilledPerLevel[Level - 1];
                
            }
        }

        new void Start()
        {
            base.Start();
            setTroopsKilledText();
        }

        new void upgrade()
        {
            base.upgrade();
            setTroopsKilledText();
        }
        void  setTroopsKilledText() //method to set set current text of how many enemies the tower will kill
        {
            if(TroopsKilled==1)
            {
                troopsKilledText.text = "The tower will kill " + TroopsKilled.ToString() + " enemy before it reaches the village";
            }
            else
            {
                troopsKilledText.text = "The tower will kill " + TroopsKilled.ToString() + " enemies before they reach the village";
            }
        }

    }
}
