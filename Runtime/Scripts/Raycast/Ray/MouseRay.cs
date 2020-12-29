using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class MouseRay : MonoBehaviour, IRay
    {
        GameObject mouseRay;
        Ray _ray;

        public GameObject raySource
        {
            get
            {
                mouseRay.transform.position = ray.origin;
                mouseRay.transform.rotation = Quaternion.LookRotation(ray.direction, Vector3.up);
                return mouseRay;
            }
        }

        public Ray ray => Camera.main.ScreenPointToRay(Input.mousePosition);

        private void Start()
        {
            mouseRay = new GameObject();
            mouseRay.name = "mouseRay";
            mouseRay.transform.parent = transform;
        }
    }
}