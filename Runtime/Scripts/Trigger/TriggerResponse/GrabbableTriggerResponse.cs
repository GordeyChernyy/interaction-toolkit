using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{

    public class GrabbableTriggerResponse : MonoTriggerResponse
    {
        private IGrabbable grabbable
        {
            get
            {
                if (_selection.selectedObject != null)
                {
                    return _selection.selectedObject.GetComponent<IGrabbable>();
                }
                return null;
            }
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Press()
        {
            if (grabbable == null) return;

            grabbable.Interact(_interactor, InteractionType.Grab);
        }

        public override void Release()
        {
            if (grabbable == null) return;

            grabbable.Interact(_interactor, InteractionType.Release);
        }
    }
}