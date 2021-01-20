using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeChgCus : KnowledgeChanged
{
    string key;

    public KnowledgeChgCus(string _key, object _value, bool _isNot = false) : base(_value, _isNot)
    {
        key = _key;
    }

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
