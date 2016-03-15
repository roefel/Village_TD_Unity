using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Village_TD
{
    class InputFieldArchers : MonoBehaviour
    {
        void Start()
        {
            var input = gameObject.GetComponent<InputField>();
            var se = new InputField.OnChangeEvent();
            se.AddListener(SubmitName);
            input.onValueChange = se;

        }

        private void SubmitName(string numberToCreate)
        {
            Debug.Log(numberToCreate);
            GameObject.Find("Barrack").GetComponent<Barrack>().numberToCreateArchers = numberToCreate;
        }

    }
}
