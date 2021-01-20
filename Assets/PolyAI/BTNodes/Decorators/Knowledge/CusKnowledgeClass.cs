using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CusKnowledgeClass : Decorator
{
    string key;
    string classType;

    public CusKnowledgeClass(string _key, string _classType, bool _isNot = false) : base(_isNot)
    {
        key = _key;
        classType = _classType;
    }

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
