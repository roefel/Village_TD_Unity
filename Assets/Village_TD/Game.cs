using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Village_TD
{
    class Game : MonoBehaviour
    {
        private double countdownTimer;
        public Text timerText;
        private string timerTextString;
        private int seconds;
        private int wave;

        private int swordfighterStrength = 1;
        private int archerStrength = 2;
        private int knightStrenght = 4;

        private readonly int[] enemyTroopsPerWave = { 1, 2, 5, 9, 15, 24, 39, 63, 102, 165, 267, 432, 699, 1131, 1830 };

        // Use this for initialization
        void Start()
        {
            countdownTimer = 60;
            wave = 1;

        }

        // Update is called once per frame
        void Update()
        {
            countdownTimer -= Time.deltaTime;
            seconds = Convert.ToInt32(countdownTimer);
            timerTextString = TimeSpan.FromSeconds(seconds).ToString(); //displays int in timenotation hh:mm:ss
            timerText.text = timerTextString;
            if(seconds<=0)
            {
                Debug.Log("attack");
                enemyAttack();
                countdownTimer = 30;
                wave++;
            }


        }

        void enemyAttack()
        {
            if(enemyTroopsPerWave[wave-1] <= (GameObject.Find("Barrack").GetComponent<Barrack>().NumSwordfighters*swordfighterStrength + GameObject.Find("Barrack").GetComponent<Barrack>().NumArchers*archerStrength + GameObject.Find("Barrack").GetComponent<Barrack>().NumKnights*knightStrenght))
            {


                Debug.Log("you defeated wave:" + wave.ToString());
            }
            else
            {
                Debug.Log("You lost at wave:" + wave.ToString());
            }
        }
    }
}
