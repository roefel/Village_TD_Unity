using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Village_TD
{
    class Combatant:Person
    {
        private int[] materialsCosts = new int[3];
        private int amTroops;

        public int[] MaterialsCosts{
            get{ return materialsCosts; }
            set{ materialsCosts = value; }
        }

        public int AmTroops{
            get{ return amTroops; }
            set{ amTroops = value; }
        }

        //void sumOfTroops()
        //{
        //    AmTroops = GameObject.Find("amSwordfighters").GetComponent<Swordfighter>().amSwordfighters  // som van aantal zwaardvechters
        //    + GameObject.Find("amArchers").GetComponent<Archer>().amArchers                             // + aantal boogschutters
        //    + GameObject.Find("amKnights").GetComponent<Knight>().amKnights;                            // + aantal ridders
        //}


    }
}
