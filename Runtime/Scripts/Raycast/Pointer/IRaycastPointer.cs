using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface IRaycastPointer
    {
        RaycastInteractor interactor { get; set; }
        void OnRayEnter(GameObject obj);
        void OnRayExit();
    }
}