using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public override NodeState Tick()
    {
        // Check for every children until one successes
        for (int i = lastRunning; i < child.Count; i = ++lastRunning)
        {
            state = child[i].Tick();

            if (state != NodeState.Failure)
            {
                // If success, reset of the selector
                if (state == NodeState.Success)
                {
                    lastRunning = 0;
                }
                return state;
            }
        }
        // If no child succeded
        lastRunning = 0;
        return NodeState.Failure;
    }
}
