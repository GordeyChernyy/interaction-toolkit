using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class Selectable : MonoBehaviour, ISelectable
    {
        public bool isDebug = false;

        public void OnEnter()
        {
            if (isDebug) Debug.Log("OnEnter " + gameObject.name);
        }

        public void OnExit()
        {
            if (isDebug) Debug.Log("OnExit " + gameObject.name);
        }
    }
}