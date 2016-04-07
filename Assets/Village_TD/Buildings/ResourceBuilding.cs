using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class ResourceBuilding:Building
    {

        public static readonly int[] numLevelPerSec = { 5, 10, 20, 40, 80, 120, 160, 220, 260, 300 };//array to define number of resources gained per second

        public override int maxLevel()
        {
            return numLevelPerSec.Length;   //the max level is defined by the array length of numLevelPerSec
        }


        private int numberOfResource;   //number of each resource: clay, iron, wood
        public Text numberOfResourceText;   //variable of type text to show int numberOfResources in unity


        public int NumberOfResource //property of numberOfResources, to make it accesable
        {
            get
            {
                return numberOfResource;
            }

            set
            {
                numberOfResource = value;
                numberOfResourceText.text = numberOfResource.ToString();    //displays numberOfResources in unity
            }
        }

        public int NumPerSec    //int to define current NumPerSec gained for the current level
        {
            get
            {
                return numLevelPerSec[Level - 1];
            }
        }

        new void Start()
        {
            base.Start();   //does what the start method does in the superclass
            raiseResources();   //calls for method to start raising resources each second.
        }

        void raiseResources()
        {

            InvokeRepeating("raiseResource", 1, 1f); //invokerepeat is a method that repeats given method in a string. repeat rate can be chosen
        }




        void raiseResource()    //method to add resources gained per second to current number of resources
        {
            int maxStorage = GameObject.Find("Warehouse").GetComponent<Warehouse>().MaxStorage; //places the current Warehouse.maxStorage in local maxStorage

            if (NumberOfResource >= maxStorage)
            {
                //message can be shown if maxstorage is reached

            }

            else if (NumberOfResource < maxStorage)
            {
                NumberOfResource += NumPerSec;  //raises the number of a resource with numpersec 


                if (NumberOfResource > maxStorage)  //then checks if the number of resource exceeded maxstorage, if so the numberofresource is set equal to maxstorage
                {
                    NumberOfResource = maxStorage;
                }
            }


          
        }
    }
}
