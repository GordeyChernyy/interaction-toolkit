using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class TransformRefTriggerResponse : MonoTriggerResponse, ITriggerResponse
    {
        private IReference<Transform> reference
        {
            get
            {
                if (_selection.selectedObject != null)
                {
                    return _selection.selectedObject.GetComponent<IReference<Transform>>();
                }
                return null;
            }
        }

        bool isPress = false;

        public override void Start()
        {
            base.Start();

            _interactor = interactor.GetComponent<IInteractor>();
        }

        public override void Press()
        {
            if (reference == null) return;

            reference.Send(_interactor.source.transform);
        }

        public override void Release()
        {
           
        }

    }
}