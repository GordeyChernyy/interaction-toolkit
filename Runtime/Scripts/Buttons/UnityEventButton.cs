using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public class UnityEventButton : MonoBehaviour, IInteractable, ISelectable
    {
        public UnityEvent onPress;
        public UnityEvent onRelease;
        public UnityEvent onEnter;
        public UnityEvent onExit;

        public void Interact(IInteractor interactor, InteractionType type)
        {
            if (type == InteractionType.Press)
            {
                onPress.Invoke();
            }
            if (type == InteractionType.Release)
            {
                onRelease.Invoke();
            }
        }

        public void OnEnter()
        {
            onEnter.Invoke();
        }

        public void OnExit()
        {
            onExit.Invoke();
        }
    }
}