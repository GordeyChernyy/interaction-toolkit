using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public class InteractableTag : MonoBehaviour, IInteractable
    {
        public void Interact(IInteractor interactor, InteractionType type)
        {
        }
    }
}