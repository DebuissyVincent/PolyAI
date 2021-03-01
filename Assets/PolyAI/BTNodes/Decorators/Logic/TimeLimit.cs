using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : Decorator
{
    float time;
    float timer;

    public TimeLimit(bool _isNot = false) : base(_isNot)
    {
    }

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
