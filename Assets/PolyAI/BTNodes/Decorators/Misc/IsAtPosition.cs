using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAtPosition : Decorator
{
    float minRange;
    float maxRange;
    bool usePathfinding;
    bool useNavGoal;
    string knowledgePos;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
