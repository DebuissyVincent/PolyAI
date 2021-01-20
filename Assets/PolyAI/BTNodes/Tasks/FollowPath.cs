using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : BTNode
{
    Vector3[] destination;
    float minRange;
    float maxRange;

    public override NodeState Tick()
    {
        return NodeState.Success;
    }
}
