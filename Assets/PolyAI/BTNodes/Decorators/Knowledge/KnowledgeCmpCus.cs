using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCmpCus : KnowledgeCompare
{
    string key;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
