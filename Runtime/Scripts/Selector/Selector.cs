using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public abstract class Selector : MonoBehaviour
    {
        public Action<GameObject> onObjSelect;
        public Action onObjRelease;

        public GameObject selectedObject { get; set; }
        public ISelectable selectable { get; set; }
        public abstract void Select(GameObject obj);
        public abstract void Release();
    }
}