using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public class RadioButtonEvents : MonoBehaviour
    {
        public UnityEvent onButtonOn;

        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnEnable()
        {
            RadioButton button = GetComponent<RadioButton>();
            button.OnInteract += OnInteract;
        }
        private void OnDisable()
        {
            RadioButton button = GetComponent<RadioButton>();
            button.OnInteract -= OnInteract;
        }

        private void OnInteract(RadioButton obj)
        {
            if(obj.state == RadioButtonState.On)
            {
                onButtonOn.Invoke();
            }
        }
    }
}