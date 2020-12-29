using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class GameObjectRay : MonoBehaviour, IRay
    {
        [SerializeField]
        private GameObject _raySource;
        Ray _ray = new Ray();

    
        public Ray ray
        {
            get
            {
                _ray.direction = raySource.transform.TransformDirection(Vector3.forward);
                _ray.origin = raySource.transform.position;
                return _ray;
            }
        }

        public GameObject raySource => _raySource;


    }
}