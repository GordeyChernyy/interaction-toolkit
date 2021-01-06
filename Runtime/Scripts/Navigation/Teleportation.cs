using Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.synestheticecho.interactiontoolkit
{
    public class Teleportation : MonoBehaviour, IInteractable, ISelectable
    {
        public GameObject cameraRig;

        RaycastReceiver receiver;

        public void Interact(IInteractor interactor, InteractionType type)
        {
            if (type == InteractionType.Press)
            {
                cameraRig.transform.position = receiver.hit.point;
            }
        }

        private void Start()
        {
            receiver = GetComponent<RaycastReceiver>();
        }

        public void OnEnter()
        {
           
        }

        public void OnExit()
        {
            
        }
    }
}