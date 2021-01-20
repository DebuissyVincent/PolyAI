using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : Decorator
{
    float time;
    float timer;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
