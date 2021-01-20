using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCmpTypeCus : KnowledgeCmpDouble
{
    KnowledgeType type;
    string key;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
