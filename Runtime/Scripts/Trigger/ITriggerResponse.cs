using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface ITriggerResponse
    {
        void Press();
        void Release();
    }
}