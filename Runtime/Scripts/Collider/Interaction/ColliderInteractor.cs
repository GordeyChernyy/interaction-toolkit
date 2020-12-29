using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction {
    public class ColliderInteractor : MonoBehaviour, IInteractor
    {
        public GameObject source => gameObject;
        public Selector selector;

        bool _isEnabled;
        public bool isEnabled {
            get => _isEnabled;
            set {
                _isEnabled = value;
                if(!_isEnabled)
                    selector.Release();
            } }

        public List<GameObject> blockedInteractors;
        public List<IInteractor> _blockInteractors = new List<IInteractor>();

        // Start is called before the first frame update
        void Start()
        {
            isEnabled = true;

            foreach(var b in blockedInteractors)
            {
                _blockInteractors.Add(b.GetComponent<IInteractor>());
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isEnabled) return;

            var receiver = other.GetComponent<ColliderReceiver>();
            if (receiver == null) return;
            receiver.interactor = this;

            foreach(var b in _blockInteractors)
            {
                b.isEnabled = false;
            }

            selector.Select(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            foreach (var b in _blockInteractors)
            {
                b.isEnabled = true;
            }

            if (!isEnabled) return;

            var receiver = other.GetComponent<ColliderReceiver>();
            if (receiver == null) return;

            selector.Release();
        }
    }
}