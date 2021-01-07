using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface IRaycast
    {
        bool IsHit(IRay ray, out RaycastHit hit, int layerMask);
    }
}