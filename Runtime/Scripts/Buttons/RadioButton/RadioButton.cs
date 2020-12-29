using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public enum RadioButtonState
    {
        On, Off
    }

    public abstract class RadioButton : MonoBehaviour, IInteractable, ISelectable
    {
        public int token;
        public RadioButtonState state;
        public Action<RadioButton> OnInteract;

        public void Interact(IInteractor interactor, InteractionType type)
        {
            if (type == InteractionType.Press)
            {
                switch (state)
                {
                    case RadioButtonState.On:
                        TurnOff();
                        break;
                    case RadioButtonState.Off:
                        TurnOn();
                        break;
                }
                OnInteract?.Invoke(this);
            }

        }

        public abstract void OnEnter();

        public abstract void OnExit();

        public virtual void TurnOn()
        {
            state = RadioButtonState.On;
        }

        public virtual void TurnOff()
        {
            state = RadioButtonState.Off;
        }

    }
}