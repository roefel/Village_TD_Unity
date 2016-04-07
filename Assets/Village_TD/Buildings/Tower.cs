using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class Tower : DefenseBuilding
    {
        readonly int[] troopsKilledPerLevel = { 1, 2, 4, 7, 10, 23, 56, 86, 123, 200 };
        private int troopsKilled;

        public Text troopsKilledText;

        public override int maxLevel()
        {
            return troopsKilledPerLevel.Length;

        }

        public int TroopsKilled
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
        void  setTroopsKilledText()
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
