using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public override NodeState Tick()
    {
        for (int i = lastRunning; i < child.Count; i = ++lastRunning)
        {
            state = child[i].Tick();

            if (state != NodeState.Failure)
            {
                if (state == NodeState.Success)
                {
                    lastRunning = 0;
                }
                return state;
            }
        }
        lastRunning = 0;
        return NodeState.Failure;
    }
}
