using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    private bool isBreakable;

    public Sequence(bool _isBreakable = false)
    {
        isBreakable = _isBreakable;
    }

    public override NodeState Tick()
    {
        // Will tick all children in an orderly sequence
        state = child[lastRunning].Tick();

        switch (state)
        {
            case NodeState.Failure:
                if (isBreakable)
                {
                    lastRunning = 0;
                }
                else
                {
                    lastRunning++;
                }
                break;
            case NodeState.Success:
                lastRunning++;
                break;
            default:
                break;
        }

        if (lastRunning == child.Count)
        {
            // If all children have been ticked
            lastRunning = 0;
        }
        else
        {
            state = NodeState.Running;
        }

        return state;
    }
}
