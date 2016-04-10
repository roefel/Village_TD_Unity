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
        private double countdownTimer;  //countdown timer to countdown to the next enemy wave
        private string timerTextString; //string to get current time in hh:mm:ss notation
        private string defaultStartGameText = "";   //default start gametext values used in start() method
        private int seconds;    //converted countdownTimer in int
        private int wave;       //current wave
        private int defaultStartWave = 1;   //default wave value at the start of the game
        private int defaultStartCountDownTimer = 60;    //default countdownTimer value at start of the game
        private int defaultWavecountdownTimer = 30;     //default countdownTimer value after each wave

        public Text timerText;  //game related text variables
        public Text waveText;
        public Text numWaveText;
        public Text restartText;
        public Text gameOverText;
        public Text gameWonText;
        public Text quitText;

        bool gameStop;  //bool used to stop the game

        System.Random rnd = new System.Random();
        private int random;

        private readonly int[] enemyTroopsPerWave = { 1, 2, 4, 6, 10, 15, 21, 38, 65, 98, 158, 232, 359, 480, 700 };    //troops that will attack your village each wave
        private int enemiesLeft;    //int that hold the amount of enemies left to fight in attack calculation

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
        void Start()    //method sets variables to default start values
        {
            countdownTimer = defaultStartCountDownTimer;
            wave = defaultStartWave;
            setWaveText();
            GameStop = false;
            gameOverText.text = defaultStartGameText;
            restartText.text = defaultStartGameText;
            gameWonText.text = defaultStartGameText;
            quitText.text = defaultStartGameText;        
        }

        // Update is called once per frame
        void Update()
        {
            countdownTimer -= Time.deltaTime;
            seconds = Convert.ToInt32(countdownTimer);
            timerTextString = TimeSpan.FromSeconds(seconds).ToString(); //displays int in timenotation hh:mm:ss
            if(!GameStop)   //if gamestop is true, stop updating timerText
            {
                timerText.text = timerTextString;
            }
            if (seconds<=0 &&!GameStop) //if countdownTimer reaches 0 the next wave will attack
            {
                enemyAttack();
                if(GameStop)
                {
                    gameOverText.text = "Game Over";
                    Debug.Log("Game Over");

                }
                else
                {
                    countdownTimer = defaultWavecountdownTimer;
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
                GameObject.Find("ClayPit").GetComponent<ClayPit>().upgradeButton.interactable = false;
                GameObject.Find("IronMine").GetComponent<IronMine>().upgradeButton.interactable = false;
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
                if (Input.GetKeyDown(KeyCode.R))    //wait for key press 'R' to reset the game
                {
                    Debug.Log("restart");
                    Application.LoadLevel(Application.loadedLevel);
                }
                if (Input.GetKeyDown(KeyCode.Escape))   //wait for key press 'ESC' to quit the game
                {
                    Debug.Log("quit");
                    Application.Quit();
                }
            }


        }

        void enemyAttack() //method that attacks your village with the number of enemy troops dependable on current wave
        {
            
            
            if (enemyTroopsPerWave[wave-1] - GameObject.Find("Tower").GetComponent<Tower>().TroopsKilled <= GameObject.Find("Barrack").GetComponent<Barrack>().TotalStrength) //checks if player has enough troops to win the fight
            {
                enemiesLeft = enemyTroopsPerWave[wave - 1];
                enemiesLeft -= GameObject.Find("Tower").GetComponent<Tower>().TroopsKilled; //tower kills a number of enemies before the actual 'fight' starts
                for (int i = 0; i < enemiesLeft;)
                {
                    random = rnd.Next(1, 4);    //random + switch is used to make it random which troops will die during the enemy attack
                    switch (random)
                    {
                        case 1:
                            if (GameObject.Find("Barrack").GetComponent<Barrack>().NumSwordfighters > 0)
                            {
                                GameObject.Find("Barrack").GetComponent<Barrack>().NumSwordfighters--;
                                enemiesLeft -= GameObject.Find("Wall").GetComponent<Wall>().SwordfighterStrength;
                            }

                            break;
                        case 2:
                            if (GameObject.Find("Barrack").GetComponent<Barrack>().NumArchers > 0)
                            {
                                GameObject.Find("Barrack").GetComponent<Barrack>().NumArchers--;
                                enemiesLeft -= GameObject.Find("Wall").GetComponent<Wall>().ArcherStrength;
                            }

                            break;
                        case 3:
                            if (GameObject.Find("Barrack").GetComponent<Barrack>().NumKnights > 0)
                            {
                                GameObject.Find("Barrack").GetComponent<Barrack>().NumKnights--;
                                enemiesLeft -= GameObject.Find("Wall").GetComponent<Wall>().KnightStrength;
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

        void setWaveText()  //updates the wave text after a wave is cleared
        {
            waveText.text = "Enemy troops next wave: " + enemyTroopsPerWave[wave - 1].ToString();
            numWaveText.text = "wave: " + wave.ToString();
        }


    }
}
