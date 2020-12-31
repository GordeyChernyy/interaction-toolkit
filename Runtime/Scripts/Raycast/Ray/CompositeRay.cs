using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Interaction
{
    public class CompositeRay : MonoBehaviour, IRay
    {
        [SerializeField]
        private GameObject rayHolder;

        private List<IRay> rays;

        [SerializeField]
        private int curRayNum;

        public GameObject raySource => rays[curRayNum].raySource;

        public Ray ray => rays[curRayNum].ray;

        // Start is called before the first frame update
        void Start()
        {
            rays = rayHolder.GetComponents<IRay>().ToList();
        }

        public void SetTo(int mode)
        {
            curRayNum = mode;

        }
    }
}