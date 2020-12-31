using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface IGrabbable
    {
        void Interact(IInteractor interactor, InteractionType type);
    }
}