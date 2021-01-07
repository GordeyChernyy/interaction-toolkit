using System;
using UnityEngine;

namespace Interaction
{
    class RaycastSwitcher : MonoBehaviour
    {
        public Selector selector;
        public CompositeRaycast raycast;
        public CompositeRaycastPointer pointer;

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
            pointer.SetTo(null, null);
        }

        private void OnObjSelect(GameObject obj)
        {
            RaycastReceiver receiver = obj.GetComponent<RaycastReceiver>();

            if (receiver == null) return;

            switch (receiver.type)
            {
                case RaycastReceiverType.Parabolic:
                    {
                        raycast.SetTo(typeof(ParabolicRaycast));
                        pointer.SetTo(typeof(ParabolicPointer), obj);
                        break;
                    }
                case RaycastReceiverType.Laser:
                    {
                        raycast.SetTo(typeof(LinearRaycast));
                        pointer.SetTo(typeof(RaycastLaserPointer), obj);
                        break;
                    }
                case RaycastReceiverType.Bezier:
                    {
                        raycast.SetTo(typeof(LinearRaycast));
                        pointer.SetTo(typeof(RaycastBezierPointer), obj);
                        break;
                    }
            }
        }
    }
}
