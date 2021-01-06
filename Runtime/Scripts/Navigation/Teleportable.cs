using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Teleportable : MonoBehaviour, ITeleportable
    {
        RaycastReceiver receiver;

        public Vector3 Position => receiver.hit.point;

        // Todo : orientation
        public Quaternion Orientation => Quaternion.identity;

        public bool isOrient => false;

        private void Start()
        {
            receiver = GetComponent<RaycastReceiver>();
        }

    }
}