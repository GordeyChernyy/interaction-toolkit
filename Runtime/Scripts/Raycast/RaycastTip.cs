using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    [RequireComponent(typeof(RaycastReceiver))]
    public class RaycastTip : MonoBehaviour
    {
        RaycastReceiver receiver { get; set; }

        public bool isParent = true;
        public float offset;
        public GameObject  tipPrefab;
        public GameObject tip { get; set; }

        public bool isLookAtCamera = false;

        // Start is called before the first frame update
        void Start()
        {
            receiver = GetComponent<RaycastReceiver>();

            if (isParent)
            {
                tip = Instantiate(tipPrefab, transform);
            }
            else
            {
                tip = Instantiate(tipPrefab);
            }
            tip.SetActive(false);
        }

        private void OnDisable()
        {
            if(tip!=null) tip.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (!receiver.isSelf)
            {
                tip.SetActive(false);
                return;
            }

            tip.SetActive(true);
            tip.transform.position = receiver.hit.point + receiver.hit.normal * offset;

            if (isLookAtCamera) tip.transform.LookAt(Camera.main.transform.position, Vector3.up);
        }


    }
}