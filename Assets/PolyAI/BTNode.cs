using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeState
{
    Failure,
    Success,
    Running,
    Error,
}

public abstract class BTNode
{
    protected NodeState state = NodeState.Error;

    public abstract NodeState Tick();
}
