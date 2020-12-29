using EasyButtons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    [System.Serializable]
    public class IntEvent : UnityEvent<int> { }

    public class RadioButtonGroup : MonoBehaviour
    {
        public int token;

        public RadioButton[] buttons;
        public RadioButton selectedButton;

        public IntEvent onChange;

        public bool isActive { get; set; }

        bool isInitialized = false;

        private void Start()
        {
            isActive = true;
        }


        private void Update()
        {
            if (isInitialized) return;

            TurnOffOthers(selectedButton);

            if (selectedButton != null)
            {
                selectedButton.TurnOn();
                onChange?.Invoke(selectedButton.token);
            }

            isInitialized = true;
        }

        private void OnEnable()
        {
            foreach (var b in buttons)
            {
                b.OnInteract += OnInteract;
            }

        }

        public void SetMode(RadioButton obj)
        {
            TurnOffOthers(obj);
            obj.TurnOn();
            selectedButton = obj;
            onChange.Invoke(obj.token);
        }
        
        private void OnDisable()
        {
            foreach (var b in buttons)
            {
                b.OnInteract -= OnInteract;
            }
        }

        private void OnInteract(RadioButton obj)
        {
            if (obj.state == RadioButtonState.On)
            {
                TurnOffOthers(obj);
                onChange.Invoke(obj.token);
            }

            if (obj.state == RadioButtonState.Off) // You can't turn off button in group
                obj.TurnOn();
        }

        public void TurnOffOthers(RadioButton obj)
        {
            foreach (RadioButton b in buttons)
            {
                if (b != obj)
                {
                    b.TurnOff();
                }
            }
        }

        [Button]
        public void GetButtons()
        {
            buttons = GetComponentsInChildren<RadioButton>();
        }

        [Button]
        public void ShowSelected()
        {
            TurnOffOthers(selectedButton);
        }
    }
}