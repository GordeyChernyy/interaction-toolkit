using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interaction;
using System.Linq;

namespace Interaction
{
    public abstract class MonoTriggerResponse : MonoBehaviour, ITriggerResponse
    {
        public GameObject triggers;
        public Selector _selection;
        public GameObject interactor;

        protected List<ITrigger> _triggers;


        protected IInteractor _interactor;

        public abstract void Press();

        public abstract void Release();

        // Start is called before the first frame update
        public virtual void Start()
        {
            _triggers = triggers.GetComponents<ITrigger>().ToList();
            _interactor = interactor.GetComponent<IInteractor>();

            foreach (var t in _triggers)
            {
                t.triggerResponse = this;
            }
        }

    }
}