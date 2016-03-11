using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Village_TD
{
    public class Timer : MonoBehaviour
    {


        private double timer;
        public Text timerText;
        private string timerTextString;
        private int seconds;


        // Use this for initialization
        void Start()
        {
            timer = 0;
            

        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            seconds = Convert.ToInt32(timer);
            timerTextString = System.TimeSpan.FromSeconds(seconds).ToString(); //displays int in timenotation hh:mm:ss
            timerText.text = timerTextString;



        }

    }
}
