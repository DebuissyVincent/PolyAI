using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrDecorator : Decorator
{
    Decorator[] firstConditions;
    Decorator[] secondConditions;

    public OrDecorator(BTNode _child, Decorator[] _firstConditions, Decorator[] _secondConditions, bool _isNot = false)
        : base(_isNot)
    {
        firstConditions = _firstConditions;
        secondConditions = _secondConditions;
        child = _child;

        for (int i = 0; i < firstConditions.Length - 1; i++)
        {
            firstConditions[i].SetChild(firstConditions[i + 1]);
        }
        for (int i = 0; i < secondConditions.Length - 1; i++)
        {
            secondConditions[i].SetChild(secondConditions[i + 1]);
        }

        firstConditions[firstConditions.Length - 1].SetChild(child);
        secondConditions[firstConditions.Length - 1].SetChild(child);
    }

    public override NodeState Tick()
    {
        state = firstConditions[0].Tick();
        if (state == NodeState.Failure)
        {
            state = secondConditions[0].Tick();
        }
        if (isNot)
        {
            if (state == NodeState.Failure)
            {
                state = NodeState.Success;
            }
            else if (state == NodeState.Success)
            {
                state = NodeState.Failure;
            }
        }
        return state;
    }
}
