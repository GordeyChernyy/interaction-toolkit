using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class ParabolicPointer : MonoBehaviour, IRaycastPointer
    {
        public RaycastInteractor interactor { get; set; }
        public ParabolicRaycast raycast;

        public LineRenderer lineRenderer;
        public int segments = 50;
        private void Start()
        {
            lineRenderer.enabled = false;
            lineRenderer.positionCount = segments;
        }

        public void OnRayEnter(GameObject obj)
        {
            IsEnabled = obj.GetComponent<RaycastReceiver>().type == RaycastReceiverType.Parabolic;
        }

        public void OnRayExit()
        {
            IsEnabled = false;
        }

        bool _IsEnabled = false;

        bool IsEnabled {
            get {
                if (raycast == null)
                {
                    return false;
                }
                
                return _IsEnabled;
            }
            set
            {
                _IsEnabled = value;
            }
        }

        private void Update()
        {
            lineRenderer.enabled = IsEnabled;
            if (!IsEnabled) return;

            lineRenderer.SetPosition(0, raycast.Origin);
            Vector3 v = raycast.Velocity;
            Vector3 a = raycast.Acceleration;
            float recip = 1.0f / (float)(segments - 1);
            for (int i = 1; i < segments; i++)
            {
                float t = (float)i * recip;
                t *= raycast.FlightTime;

                if (t > raycast.HitTime)
                {
                    t = raycast.HitTime;
                }

                lineRenderer.SetPosition(i, raycast.SampleCurve(raycast.Origin, v, a, t));
            }
        }
    }
}