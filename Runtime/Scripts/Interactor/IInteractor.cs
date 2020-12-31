using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Interaction
{
    public interface IInteractor
    {
        bool isEnabled { get; set; }
        GameObject source { get; }
    }
}