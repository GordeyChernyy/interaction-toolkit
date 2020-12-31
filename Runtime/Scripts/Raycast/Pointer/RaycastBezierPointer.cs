using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public class RaycastBezierPointer : MonoBehaviour, IRaycastPointer
    {
        bool isEnabled = false;
        RaycastReceiver rayReceiver;
        SelectionReceiver selectionReceiver;

        public LineRenderer lineRenderer;

        public int positionCount = 10;

        public Vector3 startPos { get => interactor.GetRayOrigin(); }
        public Vector3 startDir{ get => interactor.GetRayDirection(); }
        public Transform end { get { return rayReceiver?.snapTarget?.transform; } }

        public RaycastInteractor interactor { get; set; }


        // Start is called before the first frame update
        void Start()
        {
            lineRenderer.positionCount = positionCount;
        }

        public void OnRayEnter(GameObject obj)
        {
            rayReceiver = obj.GetComponent<RaycastReceiver>();
            selectionReceiver = obj.GetComponent<SelectionReceiver>();

            isEnabled = (rayReceiver != null);
        }

        public void OnRayExit()
        {
            if (!rayReceiver) return;
            if (selectionReceiver == null) return;

            if (!selectionReceiver.isKeepSelectionOnLost) isEnabled = false;
        }


        // Update is called once per frame
        void Update()
        {
            if (!isEnabled || !end)
            {

                lineRenderer.enabled = false;
                return;
            }

            if (rayReceiver.type != RaycastReceiverType.Bezier)
            {
                lineRenderer.enabled = false;
                return;
            }

            lineRenderer.enabled = true;

            for (int i = 0; i < positionCount; i++)
            {
                Vector3 diff = startPos - end.position;

                Vector3 fwd = startDir * diff.magnitude / 3f;
                Vector3 p1 = startPos;
                Vector3 p2 = startPos + fwd;
                Vector3 p3 = end.position + new Vector3(fwd.x, fwd.y, fwd.z * -1) * 0.02f;
                Vector3 p4 = end.position;
                float t = i / (float)(positionCount - 1);

                Vector3 p = GetPoint(p1, p2, p3, p4, t);
                lineRenderer.SetPosition(i, p);
            }
        }

        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            t = Mathf.Clamp01(t);
            float oneMinusT = 1f - t;
            return
                oneMinusT * oneMinusT * oneMinusT * p0 +
                3f * oneMinusT * oneMinusT * t * p1 +
                3f * oneMinusT * t * t * p2 +
                t * t * t * p3;
        }

       
    }
}