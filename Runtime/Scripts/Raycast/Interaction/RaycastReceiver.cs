using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public enum RaycastReceiverType
    {
        Laser, Bezier, Parabolic
    }

    public class RaycastReceiver : MonoBehaviour
    {
        public RaycastReceiverType type;

        public RaycastHit hit { get => interactor.hit; }
        public Vector3 source { get => interactor.GetRayOrigin(); }
        public RaycastInteractor interactor { private get; set; }

        [Tooltip("(Only for Bezier Mode) Leave it blank to use this gameobject as target")]
        [SerializeField]
        private GameObject _snapTarget;
        public GameObject snapTarget { get => _snapTarget != null ? _snapTarget : gameObject; }

        public bool isSelf {
            get {
                if (interactor == null || interactor.curHitObj == null) return false;

                return interactor.curHitObj == gameObject;
            } }

        public bool _isLockSelection;
        public bool isLockSelection { get => _isLockSelection; set {
                if(value)
                {
                    interactor.enabled = false;
                }
                else
                {
                    interactor.enabled = true;
                }
            } }
      
        public void BlockRaycast()
        {
            isLockSelection = false;
        }

        public void ReleaseRaycast()
        {
            isLockSelection = true;
        }
    }
}