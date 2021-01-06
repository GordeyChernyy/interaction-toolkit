using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface ITeleportable
    {
        Vector3 Position { get; }
        bool isOrient { get; }
        Quaternion Orientation { get; }
    }
}