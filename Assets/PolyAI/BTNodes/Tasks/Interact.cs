using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : BTNode
{
    Interactible target;

    public override NodeState Tick()
    {
        return NodeState.Success;
    }
}
