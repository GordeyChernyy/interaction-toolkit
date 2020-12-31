using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interaction;

namespace Interaction
{
    public class TriggerInteractor : MonoBehaviour
    {
        public IInteractable target { get; set; }

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerEnter(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {

        }
    }
}