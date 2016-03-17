using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Village_TD
{
    class Barrack:Building
    {
        
        public string numberToCreateSwordfighters;
        public string numberToCreateArchers;
        public string numberToCreateKnights;

        public GameObject InputSwordFighter;

        public override int maxLevel()
        {
            return 3; // The number 3 is dependable on the number of unique type of troops, 1 type is unlocked each level
        }




        public void createSwordfighter()
        {

            GameObject.Find("Swordfighters").GetComponent<Swordfighter>().amSwordfighters += Convert.ToInt32(numberToCreateSwordfighters);
            Debug.Log(GameObject.Find("Swordfighters").GetComponent<Swordfighter>().amSwordfighters);

        }
        public void inputFieldSwordFighters()
        {

            numberToCreateSwordfighters = InputSwordFighter.GetComponent<InputField>().text;
            Debug.Log(numberToCreateSwordfighters);

        }

        public void createArcher()
        {
            GameObject.Find("Archers").GetComponent<Archer>().amArchers += Convert.ToInt32(numberToCreateArchers);

        }

        public void createKnight()
        {
            GameObject.Find("Knights").GetComponent<Knight>().amKnights += Convert.ToInt32(numberToCreateKnights);

        }
    }
}
