using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateKnowledgeType : UpdateKnowledge
{
    KnowledgeType type;

    bool ChangeKnowledge(KnowledgeType _type, object _value)
    {
        return true;
    }

    public override NodeState Tick()
    {
        return NodeState.Success;
    }
}
