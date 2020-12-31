using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface ISelectable
    {
        void OnEnter();
        void OnExit();
    }
}