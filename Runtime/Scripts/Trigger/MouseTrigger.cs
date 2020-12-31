using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    [RequireComponent(typeof(IInteractor))]
    public class MouseTrigger : MonoBehaviour, ITrigger
    {
        public ITriggerResponse triggerResponse { get; set; }

        // Update is called once per frame
        void Update()
        {
            if (triggerResponse == null) return;

            if (Input.GetMouseButtonDown(0))
            {
                triggerResponse.Press();
            }

            if (Input.GetMouseButtonUp(0))
            {
                triggerResponse.Release();
            }
        }
    }
}