using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalLoop : Decorator
{
    Decorator condition;
    bool untilChildIsDone;

    public ConditionalLoop(Decorator _condition, bool _untilChildIsDone = false, bool _isNot = false) : base(_isNot)
    {
        condition = _condition;
        untilChildIsDone = _untilChildIsDone;
    }

    public override NodeState Tick()
    {
        state = condition.Tick();
        if (state != NodeState.Failure)
        {
            state = child.Tick();
            if (!untilChildIsDone)
            {
                return NodeState.Running;
            }
        }
        return state;
    }
}
