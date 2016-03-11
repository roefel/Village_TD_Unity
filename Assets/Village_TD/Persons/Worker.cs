using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Village_TD
{
    class Worker:Person
    {
        private int amWorkers;

        public int AmWorkers
        {
            get { return amWorkers; }
            set { amWorkers = value; }
        }

        void chekAmWorkers()
        {
            //aantal werknemers van elk gebouw ophalen, ergens in het project
            AmWorkers = GameObject.Find("workers").GetComponent<Barrack>().initialWorkersPerLevel   //aantal werknemers per level van een kazerne
            + GameObject.Find("workers").GetComponent<House>().initialWorkersPerLevel               //aantal werknemers per level van een huis
            + GameObject.Find("workers").GetComponent<Warehouse>().initialWorkersPerLevel           //aantal werknemers per level van de opslagplaats
            + GameObject.Find("workers").GetComponent<clayPit>().initialWorkersPerLevel             //aantal werknemers per level van een clay
            + GameObject.Find("workers").GetComponent<ironMine>().initialWorkersPerLevel            //aantal werknemers per level van een iron
            + GameObject.Find("workers").GetComponent<LumberMill>().initialWorkersPerLevel;         //aantal werknemers per level van een wood
        }
    }
}
