using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceStatus : Decorator
{
    NodeState forcedState;

    /// <summary>
    /// Non-blocking decorator. Will return a fixed state no matter the child's state.
    /// WARNING : May cause unwanted behaviours as subsequent nodes could be forcefully interrupted.
    /// </summary>
    /// <param name="_forcedState">The state which will be forcefully returned.</param>
    /// <param name="_isNot">Will have no effect.</param>
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
