using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public class CompositeButton : MonoBehaviour, IInteractable, ISelectable
    {
        public GameObject buttons;

        public List<IInteractable> interactables = new List<IInteractable>();
        public List<ISelectable> selectables = new List<ISelectable>();

        void Awake()
        {
            if (buttons == null) return;

            interactables = buttons.GetComponentsInChildren<IInteractable>().ToList();
            selectables = buttons.GetComponentsInChildren<ISelectable>().ToList();
        }

        public void Interact(IInteractor interactor, InteractionType type)
        {
            foreach (var i in interactables)
            {
                i.Interact(interactor, type);
            }
        }

        public void OnEnter()
        {
            foreach (var i in selectables)
            {
                i.OnEnter();
            }
        }

        public void OnExit()
        {
            foreach (var i in selectables)
            {
                i.OnExit();
            }
        }
    }
}