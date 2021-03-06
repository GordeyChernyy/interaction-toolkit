﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction
{
    public interface IRay
    {
        Ray ray { get; }
        GameObject raySource { get; }
    }
}