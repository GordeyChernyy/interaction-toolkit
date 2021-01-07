using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {

    public class Teleporter : MonoBehaviour, ITriggerResponse
    {
        public GameObject rig;
        public Selection selection;
        public GameObject trigger;


        public void Start()
        {
            trigger.GetComponent<ITrigger>().triggerResponse = this;
        }

        public void Press()
        {
            if (selection.selectedObject == null) return;

            ITeleportable teleportable = selection.selectedObject.GetComponent<ITeleportable>();

            if (teleportable == null) return;

            rig.transform.position = teleportable.Position;

            if (!teleportable.isOrient) return;

            rig.transform.rotation = teleportable.Orientation;
        }

        public void Release()
        {
            
        }
    }
}