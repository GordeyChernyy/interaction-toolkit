using System;
using UnityEngine;

namespace Interaction
{
    class RaycastSwitcher : MonoBehaviour
    {
        public Selector selector;
        public CompositeRaycast raycast;

        private void OnEnable()
        {
            selector.onObjSelect += OnObjSelect;
            selector.onObjRelease += OnObjRelease;
        }

        private void OnDisable()
        {
            selector.onObjSelect -= OnObjSelect;
            selector.onObjRelease -= OnObjRelease;
        }

        private void OnObjRelease()
        {
            raycast.SetTo(typeof(LinearRaycast));
        }

        private void OnObjSelect(GameObject obj)
        {
            RaycastReceiver receiver = obj.GetComponent<RaycastReceiver>();

            if (receiver == null) return;

            switch (receiver.type)
            {
                case RaycastReceiverType.Parabolic:
                    raycast.SetTo(typeof(ParabolicRaycast));
                    break;
                case RaycastReceiverType.Laser:
                    raycast.SetTo(typeof(LinearRaycast));
                    break;
                case RaycastReceiverType.Bezier:
                    raycast.SetTo(typeof(LinearRaycast));
                    break;
            }
        }
    }
}
