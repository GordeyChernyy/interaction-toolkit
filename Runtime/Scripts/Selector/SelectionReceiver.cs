using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public class SelectionReceiver : MonoBehaviour, ISelectionReceiver
    {
        public bool _isKeepSelectionOnLost;
        public bool isKeepSelectionOnLost => _isKeepSelectionOnLost;

        public bool isLockSelection { get; set; }
    }
}