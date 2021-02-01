using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertChanged : KnowledgeDecorator
{
    short previousValue = -1;

    public AlertChanged(KnowledgeBase _klg, bool _isNot = false) : base(_klg, _isNot)
    {

    }

    public override NodeState Tick()
    {
        // Check if alert changed
        if (previousValue == 0 || previousValue == 1 && isNot)
        {
            if (agentKnowledge.IsAlert)
            {
                state = NodeState.Failure;
            }
            else
            {
                state = child.Tick();
            }
        }
        else if (previousValue == 1 || previousValue == 0 && isNot)
        {
            if (agentKnowledge.IsAlert)
            {
                state = child.Tick();
            }
            else
            {
                state = NodeState.Failure;
            }
        }
        // Update previous alert
        if (agentKnowledge.IsAlert)
        {
            previousValue = 1;
        }
        else
        {
            previousValue = 0;
        }
        return state;
    }
}
