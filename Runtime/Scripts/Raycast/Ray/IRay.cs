using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRay
{
    Ray ray { get; }
    GameObject raySource { get;}
}
