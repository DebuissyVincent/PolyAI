using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeChgType : KnowledgeChanged
{
    object type;

    public KnowledgeChgType(object type, object _value, bool _isNot = false) : base(_value, _isNot)
    {
        this.type = type;
    }

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
