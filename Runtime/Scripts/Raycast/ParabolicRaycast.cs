using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class ParabolicRaycast : MonoBehaviour, IRaycast
    {
        [Tooltip("Tracking space of OVRCameraRig, VR space is relative to this")]
        public Transform trackingSpace;

        [Tooltip("How far ray can go")]
        public float rayDistance = 1.5f;

        [Tooltip("How manu angles from world up the surface can point and still be valid. Avoids casting onto walls.")]
        public float surfaceAngle = 5;

        [Tooltip("Initial velocity of projectile")]
        public float velocity = 10;

        [Tooltip("Initial acceleration of projectile")]
        public float acceleration = 9.8f;

        [Tooltip("Additional flight time allows parabola to dip below origin")]
        public float additionalFlightTime = 0.5f;

        [Tooltip("Number of segments used to check for collision\nSuggested to be 10% of visual parabola")]
        public int segments = 30;

        // Points of parabola
        public List<Vector3> Points => parabola;
        protected List<Vector3> parabola = new List<Vector3>();

        public float HitTime { get; protected set; }

        public Vector3 SampleCurve(Vector3 p, Vector3 v, Vector3 a, float t)
        {
            Vector3 result = new Vector3();
            result.x = p.x + v.x * t + 0.5f * a.x * t * t;
            result.y = p.y + v.y * t + 0.5f * a.y * t * t;
            result.z = p.z + v.z * t + 0.5f * a.z * t * t;
            return result;
        }

        public bool IsContact { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Origin { get; set; }
        public float FlightTime { get; set; }
        public Vector3 Acceleration { get; set; }

        public bool IsHit(IRay ray, out RaycastHit hit, int layerMask)
        {
            IsContact = false;
            hit = new RaycastHit();

            Vector3 Start = ray.ray.origin;
            Origin = Start;

            parabola.Clear();
            parabola.Add(Start);

            Vector3 last = Start;
            Vector3 v = ray.ray.direction* rayDistance;
            Vector3 a = trackingSpace.up * -1.0f * acceleration;
            Acceleration = a;

            Velocity = v;

            float recip = 1.0f / (float)(segments - 1);

            float Angle = Vector3.Angle(trackingSpace.forward, ray.ray.direction);

            float flightTime = 2.0f * velocity * Mathf.Sin(Angle * Mathf.Deg2Rad) / acceleration + additionalFlightTime;
            FlightTime = flightTime;

            for (int i = 1; i < segments; i++)
            {
                float t = (float)i * recip;
                t *= flightTime;

                Vector3 next = SampleCurve(Start, v, a, t);

                if (Physics.Linecast(last, next, out hit, layerMask))
                {
                    parabola.Add(hit.point);

                    float angle = Vector3.Angle(Vector3.up, hit.normal);
                    if (angle < surfaceAngle)
                    {

                        HitTime = t;
                        float adjust_distance = hit.distance / (last - next).magnitude;
                        adjust_distance *= recip * flightTime;
                        HitTime += adjust_distance;

                        IsContact = true;
                    }
                    break;
                }
                else
                {
                    parabola.Add(next);
                }

                last = next;
            }
            return IsContact;
        }

    }
}