using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Interaction
{

    public class CompositeRaycastPointer : MonoBehaviour, IRaycastPointer
    {
        public GameObject pointersHolder;
        public List<IRaycastPointer> pointers;

        public RaycastInteractor interactor { get; set; }

        IRaycastPointer curPointer;

        private void Start()
        {
            interactor = GetComponent<RaycastInteractor>();
            pointers = pointersHolder.GetComponents<IRaycastPointer>().ToList();
            Debug.Log("[CompositeRaycastPointer] " + interactor.name);
            foreach (var p in pointers)
                p.interactor = interactor;
        }

        public void SetTo(System.Type type, GameObject selected)
        {
            var r = pointers.Find(obj => obj.GetType() == type);

            if (r == null) {
                curPointer?.OnRayExit();
                return;
            }

            curPointer?.OnRayExit();
            curPointer = r;
            curPointer.OnRayEnter(selected);
        }

        public void OnRayEnter(GameObject obj)
        {
            //foreach (var p in pointers)
            //    p.OnRayEnter(obj);
        }

        public void OnRayExit()
        {
            //foreach (var p in pointers)
            //    p.OnRayExit();
        }
    }
}