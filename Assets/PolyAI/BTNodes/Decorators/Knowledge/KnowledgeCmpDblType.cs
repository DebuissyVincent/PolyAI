using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCmpDblType : KnowledgeCmpDouble
{
    KnowledgeType type;
    KnowledgeType type2;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
