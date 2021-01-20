using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCmpDblCus : KnowledgeCmpDouble
{
    string key;
    string key2;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
