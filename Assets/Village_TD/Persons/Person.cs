using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Village_TD
{
    class Person : MonoBehaviour
    {
        private int amPopulation;
        
        public int AmPopulation{
            get{ return amPopulation; }
            set{ amPopulation = value; }
        }
        
        //void Start() {
        //    AmPopulation = GameObject.Find("amTroops").GetComponent<Combatant>().AmTroops
        //    + GameObject.Find("amWorkers").GetComponent<Worker>().AmWorkers;
        //}
    }
}
