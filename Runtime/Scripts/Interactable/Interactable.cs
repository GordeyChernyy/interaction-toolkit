using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public class Interactable : MonoBehaviour, IInteractable
    {
        public bool isDebug;

        public void Interact(IInteractor interactor, InteractionType type)
        {
            if (isDebug) Debug.Log("Interact : " + type);
        }
    }
}