using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgePath : KnowledgeDecorator
{
    string knowlegePos;
    string knowledgePos2;

    public KnowledgePath(Knowledge _klg, string _klgPos, string _klgPos2, bool _isNot = false) : base(_klg, _isNot)
    {
        knowlegePos = _klgPos;
        knowledgePos2 = _klgPos2;
    }

    public override NodeState Tick()
    {
        return state;
    }
}
