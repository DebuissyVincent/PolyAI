using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateKnowledgeCus : UpdateKnowledge
{
    string key;

    bool ChangeKnowledge(string _key, object _value)
    {
        return true;
    }

    public override NodeState Tick()
    {
        return NodeState.Success;
    }
}
