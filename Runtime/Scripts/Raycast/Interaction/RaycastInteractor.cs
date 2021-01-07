using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class RaycastInteractor : MonoBehaviour, IInteractor
    {
        public IRay ray;
        public IRaycast raycast;
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
        private bool isHit = false;
        private bool isHitPrev = false;

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
            raycast = GetComponent<IRaycast>();
            ray = GetComponent<IRay>();
            pointer = GetComponent<IRaycastPointer>();
            layerMask = LayerMask.GetMask(layerMaskName);
        }

        // Update is called once per frame
        void Update()
        {
            if (!isEnabled) return;

            if (raycast.IsHit(ray, out _hit, layerMask))
            {
                hitPoint = _hit.point;
                curHitObj = _hit.collider.gameObject;

                RaycastReceiver receiver = curHitObj.GetComponent<RaycastReceiver>();

                if (receiver == null)
                {
                    selector.Release();
                    curHitObj = null;
                    return;
                }

                receiver.interactor = this;
                selector.Select(curHitObj);

                isHit = true;
            }
            else // nothing to hit
            {
                if (curHitObj != null)
                {
                    selector.Release();
                    curHitObj = null;
                }
                isHit = false;
            }

            if (isHitPrev != isHit)
            {
                if (isHit) {
                    pointer.OnRayEnter(curHitObj);
                }
                else
                {
                    pointer.OnRayExit();
                }
            }
            isHitPrev = isHit;
        }
    }
}