using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace Village_TD
{
    class Game : MonoBehaviour
    {
        private double countdownTimer;
        private string timerTextString;
        private int seconds;
        private int wave;

        public Text timerText;
        public Text waveText;
        public Text numWaveText;
        public Text restartText;
        public Text gameOverText;
        public Text gameWonText;
        public Text quitText;

        bool gameStop;

        System.Random rnd = new System.Random();
        private int random;

        private readonly int[] enemyTroopsPerWave = { 1, 2, 4, 6, 10, 15, 21, 38, 65, 98, 158, 232, 359, 480, 700 };
        private int enemiesLeft;

        public bool GameStop
        {
            get
            {
                return gameStop;
            }

            set
            {
                gameStop = value;
            }
        }

        // Use this for initialization
        void Start()
        {
            countdownTimer = 60;
            wave = 1;
            setWaveText();
            GameStop = false;
            gameOverText.text = "";
            restartText.text = "";
            gameWonText.text = "";
            quitText.text = "";        
        }

        // Update is called once per frame
        void Update()
        {
            countdownTimer -= Time.deltaTime;
            seconds = Convert.ToInt32(countdownTimer);
            timerTextString = TimeSpan.FromSeconds(seconds).ToString(); //displays int in timenotation hh:mm:ss
            if(!GameStop)
            {
                timerText.text = timerTextString;
            }
            if (seconds<=0 &&!GameStop)
            {
                enemyAttack();
                if(GameStop)
                {
                    gameOverText.text = "Game Over";
                    Debug.Log("Game Over");

                }
                else
                {
                    countdownTimer = 30;
                    wave++;
                    
                }
                if(wave==enemyTroopsPerWave.Length+1)
                {
                    GameStop= true;
                    gameWonText.text = "You've Won!";                                       
                    Debug.Log("you've won");
                }
                else
                {
                    setWaveText();
                }                  
            }

            if(gameStop)
            {
                GameObject.Find("Barrack").GetComponent<Barrack>().upgradeButton.interactable = false;  //disable all buttons
                GameObject.Find("ClayPit").GetComponent<clayPit>().upgradeButton.interactable = false;
                GameObject.Find("IronMine").GetComponent<ironMine>().upgradeButton.interactable = false;
                GameObject.Find("LumberMill").GetComponent<LumberMill>().upgradeButton.interactable = false;
                GameObject.Find("House").GetComponent<House>().upgradeButton.interactable = false;
                GameObject.Find("Tower").GetComponent<Tower>().upgradeButton.interactable = false;
                GameObject.Find("Warehouse").GetComponent<Warehouse>().upgradeButton.interactable = false;
                GameObject.Find("Wall").GetComponent<Wall>().upgradeButton.interactable = false;
                GameObject.Find("Barrack").GetComponent<Barrack>().createArchers.interactable = false;
                GameObject.Find("Barrack").GetComponent<Barrack>().createSwordfighters.interactable = false;
                GameObject.Find("Barrack").GetComponent<Barrack>().createKnights.interactable = false;
                restartText.text = "Press 'R' to restart";
                quitText.text = "Press 'esc' to quit";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Debug.Log("restart");
                    Application.LoadLevel(Application.loadedLevel);
                }
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Debug.Log("quit");
                    Application.Quit();
                }
            }


        }

        void enemyAttack()
        {
            
            
            if (enemyTroopsPerWave[wave-1] - GameObject.Find("Tower").GetComponent<Tower>().TroopsKilled <= GameObject.Find("Barrack").GetComponent<Barrack>().TotalStrength)
            {
                enemiesLeft = enemyTroopsPerWave[wave - 1];
                enemiesLeft -= GameObject.Find("Tower").GetComponent<Tower>().TroopsKilled;
                for (int i = 0; i < enemiesLeft;)
                {
                    random = rnd.Next(1, 4);
                    switch (random)
                    {
                        case 1:
                            if (GameObject.Find("Barrack").GetComponent<Barrack>().NumSwordfighters > 0)
                            {
                                GameObject.Find("Barrack").GetComponent<Barrack>().NumSwordfighters--;
                                enemiesLeft -= 1 * GameObject.Find("Wall").GetComponent<Wall>().SwordfighterStrength;
                            }

                            break;
                        case 2:
                            if (GameObject.Find("Barrack").GetComponent<Barrack>().NumArchers > 0)
                            {
                                GameObject.Find("Barrack").GetComponent<Barrack>().NumArchers--;
                                enemiesLeft -= 1 * GameObject.Find("Wall").GetComponent<Wall>().ArcherStrength;
                            }

                            break;
                        case 3:
                            if (GameObject.Find("Barrack").GetComponent<Barrack>().NumKnights > 0)
                            {
                                GameObject.Find("Barrack").GetComponent<Barrack>().NumKnights--;
                                enemiesLeft -= 1 * GameObject.Find("Wall").GetComponent<Wall>().KnightStrength;
                            }

                            break;
                    }
                }



                Debug.Log("you defeated wave:" + wave.ToString());
            }
            else
            {
                GameStop = true;
                Debug.Log("You lost at wave:" + wave.ToString());
            }
        }

        void setWaveText()
        {
            waveText.text = "Enemy troops next wave: " + enemyTroopsPerWave[wave - 1].ToString();
            numWaveText.text = "wave: " + wave.ToString();
        }


    }
}
