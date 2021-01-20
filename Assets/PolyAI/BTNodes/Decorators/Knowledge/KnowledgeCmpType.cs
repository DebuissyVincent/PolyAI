using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCmpType : KnowledgeCompare
{
    KnowledgeType type;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
