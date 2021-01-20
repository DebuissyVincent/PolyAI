using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgePath : Decorator
{
    string knowlegePos1;
    string knowledgePos2;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
