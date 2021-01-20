using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : Decorator
{
    int nb;
    bool isInfinite;
    float infiniteTimeoutTime;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
