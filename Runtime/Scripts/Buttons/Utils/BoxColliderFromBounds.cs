using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class BoxColliderFromBounds : MonoBehaviour
    {
        public float borderSize = 0.02f;
        // Start is called before the first frame update
        void Start()
        {
            SetBounds();
        }

        [ContextMenu("SetBounds")]
        public void SetBounds()
        {
            Quaternion tempRot = transform.rotation;
            transform.rotation = Quaternion.identity;

            var Bounds = GetChildRendererBounds(gameObject);
            if (GetComponent<BoxCollider>() == null)
            {
                gameObject.AddComponent<BoxCollider>();
            }
            var box = GetComponent<BoxCollider>();
            box.size = (Bounds.size + Vector3.one * borderSize) / transform.localScale.x;
            box.center = transform.InverseTransformPoint(Bounds.center);

            transform.rotation = tempRot;
        }

        public Bounds GetChildRendererBounds(GameObject go)
        {
            var renderers = go.GetComponentsInChildren<Renderer>();

            if (renderers.Length > 0)
            {
                Bounds bounds = renderers[0].bounds;
                foreach (var rend in renderers)
                {
                    bounds.Encapsulate(rend.bounds);
                }
                return bounds;
            }
            else { return new Bounds(); }
        }
    }
}