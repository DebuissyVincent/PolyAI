using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceStatus : Decorator
{
    NodeState forcedState;

    public ForceStatus(NodeState _forcedState, bool _isNot = false) : base(_isNot)
    {
        forcedState = _forcedState;
    }

    public override NodeState Tick()
    {
        state = child.Tick();

        return forcedState;
    }
}
