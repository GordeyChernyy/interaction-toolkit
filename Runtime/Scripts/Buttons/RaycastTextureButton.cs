using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Interaction
{
    [RequireComponent(typeof(RaycastReceiver))]
    public class RaycastTextureButton : MonoBehaviour, IInteractable, ISelectable
    {
        RaycastReceiver receiver;

        public float textureWidth;
        public float textureHeight;

        [System.Serializable]
        public class Vector2Event : UnityEvent<Vector2> { }

        public Vector2Event onHit;
        public Vector2 uv { get; set; }

        public bool isEnter = false;
        bool isTriggerEnabled = true;

        public void SetTriggerEnabled(bool value)
        {
            isTriggerEnabled = value;
        }

        // Start is called before the first frame update
        void Start()
        {
            receiver = GetComponent<RaycastReceiver>();
        }

        public void Interact(IInteractor interactor, InteractionType type)
        {
            if (type == InteractionType.Press && isTriggerEnabled)
            {
                uv = receiver.hit.textureCoord * new Vector2(textureWidth, textureHeight);
                onHit.Invoke(uv);
            }
        }

        public void OnEnter()
        {
            isEnter = true;
        }

        public void OnExit()
        {
            isEnter = false;
        }

        private void Update()
        {
            if (!isEnter) return;

            uv = receiver.hit.textureCoord * new Vector2(textureWidth, textureHeight);
        }
    }
}