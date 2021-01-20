using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BroadcastKnowledge : BTNode
{
    object value;
    float range;

    public override NodeState Tick()
    {
        return NodeState.Success;
    }
}
