using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class LinearRaycast : MonoBehaviour, IRaycast
    {
        public bool IsHit(IRay ray, out RaycastHit hit, int layerMask)
        {
            if(Physics.Raycast(ray.ray, out hit, 10f, layerMask))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}