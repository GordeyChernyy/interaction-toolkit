using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class RaycastInteractor : MonoBehaviour, IInteractor
    {
        public IRay ray;
        public IRaycastPointer pointer;
        public IInteractable target { get; set; }

        public Selector selector;

        public Vector3 hitPoint { get; set; }

        public RaycastHit _hit;
        public RaycastHit hit { get => _hit; }

        public GameObject curHitObj { get; set; }

        public GameObject source => ray.raySource;

        public bool isEnabled { get; set; }

        public string layerMaskName = "Interaction";

        int layerMask;


        public Vector3 GetRayOrigin()
        {
            return ray.ray.origin;
        }

        public Vector3 GetRayDirection()
        {
            return ray.ray.direction;
        }

        // Start is called before the first frame update
        void Start()
        {
            isEnabled = true;
            ray = GetComponent<IRay>();
            pointer = GetComponent<IRaycastPointer>();
            layerMask = LayerMask.GetMask(layerMaskName);
        }

        private void OnEnable()
        {
            selector.onObjSelect += OnObjSelect;
            selector.onObjRelease += OnObjRelease;
        }

        private void OnDisable()
        {
            selector.onObjSelect += OnObjSelect;
            selector.onObjRelease += OnObjRelease;
        }

        private void OnObjSelect(GameObject obj)
        {
            if (curHitObj != null)
                pointer.OnRayEnter(obj);
        }

        private void OnObjRelease()
        {
            if (curHitObj != null)
                pointer.OnRayExit();
        }

        // Update is called once per frame
        void Update()
        {
            if (!isEnabled) return;

            if (Physics.Raycast(ray.ray, out _hit, 10f, layerMask))
            {
                hitPoint = _hit.point;
                curHitObj = _hit.collider.gameObject;

                RaycastReceiver receiver = curHitObj.GetComponent<RaycastReceiver>();

                if (receiver == null)
                {
                    selector.Release();
                    OnObjRelease();
                    curHitObj = null;
                    return;
                }

                receiver.interactor = this;
                selector.Select(curHitObj);
            }
            else // nothing to hit
            {
                if (curHitObj != null)
                {
                    selector.Release();
                    OnObjRelease();
                    curHitObj = null;
                }
            }
        }
    }
}