using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface IReference<T>
    {
        void Send(T obj);
    }
}
