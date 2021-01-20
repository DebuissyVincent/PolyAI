using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateKnowledge : BTNode
{
    object value;
    bool common;

    public override NodeState Tick()
    {
        return NodeState.Success;
    }
}
