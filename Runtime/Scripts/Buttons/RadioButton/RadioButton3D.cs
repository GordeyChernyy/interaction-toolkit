using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Interaction
{
    public class RadioButton3D : RadioButton
    {
        public GameObject checkBox;
        public TextMeshPro text;

        public float selectedCheckboxScale = 1;
        public float hoveredCheckboxScale = 0.5f;
        // Start is called before the first frame update
        void Start()
        {
            checkBox.SetActive(state == RadioButtonState.On);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void OnEnter()
        {
            if (state == RadioButtonState.On) return;

            checkBox.transform.localScale = new Vector3(hoveredCheckboxScale, hoveredCheckboxScale, hoveredCheckboxScale);
            checkBox.SetActive(true);
        }

        public override void OnExit()
        {
            checkBox.transform.localScale = new Vector3(selectedCheckboxScale, selectedCheckboxScale, selectedCheckboxScale);
            if (state == RadioButtonState.Off) checkBox.SetActive(false);
        }

        public override void TurnOff()
        {
            base.TurnOff();
            checkBox.SetActive(false);
        }

        public override void TurnOn()
        {
            base.TurnOn();

            checkBox.SetActive(true);
            checkBox.transform.localScale = new Vector3(selectedCheckboxScale, selectedCheckboxScale, selectedCheckboxScale);
        }


    }
}