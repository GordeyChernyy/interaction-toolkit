using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Grabbable : MonoBehaviour, IGrabbable
    {
        IInteractor interactor;
        Vector3 grabPoint;
        Vector3 sourcePos => interactor.source.transform.position;

        public void Interact(IInteractor interactor, InteractionType type)
        {
            if(type == InteractionType.Grab)
            {
                Debug.Log("Grab");
                interactor.isEnabled = false;

                this.interactor = interactor;
                grabPoint =  transform.position - interactor.source.transform.position;
            }
            if(type == InteractionType.Release)
            {
                Debug.Log("Release");
                interactor.isEnabled = true;
                this.interactor = null;
            }
        }

        public void Update()
        {
            if (interactor == null) return;

            transform.position = sourcePos + grabPoint;
        }
    }
}