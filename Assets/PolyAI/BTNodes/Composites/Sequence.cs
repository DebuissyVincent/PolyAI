using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Composite
{
    [SerializeField]
    private bool isBreakable = false;

    public override NodeState Tick()
    {
        for (int i = lastRunning; i < child.Count; i = ++lastRunning)
        {
            state = child[i].Tick();

            if (state != NodeState.Success)
            {
                if (isBreakable && state != NodeState.Running)
                {
                    lastRunning = 0;
                }
                return state;
            }
        }
        lastRunning = 0;
        return NodeState.Success;
    }
}
