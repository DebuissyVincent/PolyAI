using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public override NodeState Tick()
    {
        // Will tick all children until one succeeds
        state = child[lastRunning].Tick();

        if (state != NodeState.Failure)
        {
            // If success, reset of the selector
            if (state == NodeState.Success)
            {
                lastRunning = 0;
            }
            return state;
        }

        // If no child succeeded
        if (lastRunning == child.Count)
        {
            lastRunning = 0;
        }
        else
        {
            state = NodeState.Running;
        }

        return state;
    }
}
