using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionnalLoop : Decorator
{
    Decorator condtion;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
