using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Interaction
{
    public class SimpleButton : MonoBehaviour, IInteractable, ISelectable
    {
        public bool isDebug = false;
        public string colorProperty = "_Color";

        public UnityEvent onPress;
        public UnityEvent onRelease;
        public UnityEvent onEnter;
        public UnityEvent onExit;


        public Renderer rend;

        // Start is called before the first frame update
        void Start()
        {
            rend.material.color = Color.gray;
        }

        public void Interact(IInteractor interactor,  InteractionType type)
        {
            if (type == InteractionType.Press)
            {
                if (isDebug) Debug.Log("Press " + name);
                rend.material.SetColor(colorProperty, Color.red);
                onPress.Invoke();
            }
            if (type == InteractionType.Release)
            {
                if (isDebug) Debug.Log("Release " + name);
                rend.material.SetColor(colorProperty, Color.gray);
                onRelease.Invoke();
            }
        }

        public void OnEnter()
        {
            if (isDebug) Debug.Log("OnEnter " + name);
            rend.material.SetColor(colorProperty, Color.yellow);
            onEnter.Invoke();
        }

        public void OnExit()
        {
            if (isDebug) Debug.Log("OnExit " + name);
            rend.material.SetColor(colorProperty, Color.gray);
            onExit.Invoke();
        }
    }
}