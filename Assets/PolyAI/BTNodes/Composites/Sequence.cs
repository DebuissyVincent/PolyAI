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
        for (int i = lastRunning; i < child.Count; i = ++lastRunning)
        {
            state = child[i].Tick();

            if (state != NodeState.Success)
            {
                // If sequence is breakable upon failure
                if (isBreakable && state != NodeState.Running)
                {
                    lastRunning = 0;
                }
                return state;
            }
        }
        // If all children have been ticked
        lastRunning = 0;
        return NodeState.Success;
    }
}
