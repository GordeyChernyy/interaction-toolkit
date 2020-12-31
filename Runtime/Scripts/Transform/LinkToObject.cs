using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class LinkToObject : MonoBehaviour
    {
        public GameObject target;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = target.transform.position;
            transform.rotation = target.transform.rotation;
        }
    }
}