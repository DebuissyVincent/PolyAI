using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCmpDouble : Decorator
{
    KnowledgeType type;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
