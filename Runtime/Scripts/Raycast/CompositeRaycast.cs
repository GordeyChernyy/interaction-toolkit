using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public class CompositeRaycast : MonoBehaviour, IRaycast
    {
        public GameObject raycastHolder;
        private List<IRaycast> raycasts;

        [SerializeField]
        private int curRayNum;

        IRaycast Raycast => raycasts[curRayNum];

        // Start is called before the first frame update
        void Start()
        {
            raycasts = raycastHolder.GetComponents<IRaycast>().ToList();
        }

        public void SetTo(int mode)
        {
            curRayNum = mode;
        }

        public bool IsHit(IRay ray, out RaycastHit hit, int layerMask)
        {
            return Raycast.IsHit(ray, out hit, layerMask);
        }
    }
}