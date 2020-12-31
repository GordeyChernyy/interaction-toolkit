using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Interaction {

    public class InteractableTriggerResponse : MonoTriggerResponse
    {
        private IInteractable interactable { get
            {
                if (_selection.selectedObject != null)
                {
                    return _selection.selectedObject.GetComponent<IInteractable>();
                }
                return null;
            } }

        public override void Start()
        {
            base.Start();
        }

        public override void Press()
        {
            if (interactable == null) return;

            interactable.Interact(_interactor, InteractionType.Press);
        }

        public override void Release()
        {
            if (interactable == null) return;

            interactable.Interact(_interactor, InteractionType.Release);
        }
    }
}