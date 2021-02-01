using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchKnowledge : KnowledgeDecorator
{
    string key;

    public SearchKnowledge(Knowledge _klg, string _key, bool _isNot = false) : base(_klg, _isNot)
    {
        key = _key;
    }

    public override NodeState Tick()
    {
        Knowledge knowledge = (Knowledge)agentKnowledge;
        if (knowledge.HasKnowledge(key))
        {
            if (isNot)
            {
                return NodeState.Failure;
            }
            return child.Tick();
        }
        if (isNot)
        {
            return child.Tick();
        }
        return NodeState.Failure;
    }
}
