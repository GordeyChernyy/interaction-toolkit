using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface ISelectionReceiver
    {
        bool isKeepSelectionOnLost { get; }
        bool isLockSelection { get; set; }
    }
}