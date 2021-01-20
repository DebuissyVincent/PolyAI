using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act : BTNode
{
    Animation action;

    public override NodeState Tick()
    {
        Debug.Log("Acting");
        return NodeState.Success;
    }
}
