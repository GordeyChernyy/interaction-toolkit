using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class OculusTrigger : MonoBehaviour, ITrigger
    {
        public ITriggerResponse triggerResponse { get; set; }

        public OVRInput.Controller controller;
        public OVRInput.Button button;

        // Update is called once per frame
        void Update()
        {
            if (triggerResponse == null) return;

            if (OVRInput.GetDown(button, controller))
            {
                triggerResponse.Press();
            }
            if (OVRInput.GetUp(button, controller))
            {
                triggerResponse.Release();
            }
        }
    }
}