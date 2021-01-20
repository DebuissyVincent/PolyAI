using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchCusKnowledge : Decorator
{
    string key;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
