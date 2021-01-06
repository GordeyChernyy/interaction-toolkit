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
            ITeleportable teleportable = selection.selectedObject.GetComponent<ITeleportable>();

            Debug.Log(teleportable);

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