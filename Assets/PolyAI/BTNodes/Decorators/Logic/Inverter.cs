using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Decorator
{
    public Inverter(bool _isNot = false) : base(_isNot)
    {
    }

    public override NodeState Tick()
    {
        state = child.Tick();

        if (state == NodeState.Success)
        {
            return NodeState.Failure;
        }
        else if (state == NodeState.Failure)
        {
            return NodeState.Success;
        }
        return state;
    }
}
