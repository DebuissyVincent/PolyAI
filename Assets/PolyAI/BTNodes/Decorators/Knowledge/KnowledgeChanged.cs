using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KnowledgeChanged : Decorator
{
    object previousValue;

    protected KnowledgeChanged(object _previousValue, bool _isNot) : base(_isNot)
    {
        previousValue = _previousValue;
    }

    public override NodeState Tick()
    {
        throw new System.NotImplementedException();
    }
}
