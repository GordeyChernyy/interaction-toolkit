using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public class RaycastLaserPointer : MonoBehaviour, IRaycastPointer
    {
        bool isEnabled = false;

        public LineRenderer lineRenderer;

        public Vector3 posStart { get => interactor.GetRayOrigin(); }
        public Vector3 posEnd { get => interactor.hitPoint; }

        public RaycastInteractor interactor { get ; set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        public void OnRayEnter(GameObject obj)
        {
            isEnabled = true;
        }

        public void OnRayExit()
        {
            isEnabled = false;
        }

        // Update is called once per frame
        void Update()
        {
   
            if (!isEnabled)
            {
                
                lineRenderer.enabled = false;
                return;
            }

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, posStart);
            lineRenderer.SetPosition(1, posEnd);
        }

    }
}