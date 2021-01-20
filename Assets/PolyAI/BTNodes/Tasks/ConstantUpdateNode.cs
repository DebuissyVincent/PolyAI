using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConstantUpdateNode : BTNode
{
    protected bool needsUpdate = false;

    public bool NeedsUpdate { get => needsUpdate; }

    public abstract void Update();
}
