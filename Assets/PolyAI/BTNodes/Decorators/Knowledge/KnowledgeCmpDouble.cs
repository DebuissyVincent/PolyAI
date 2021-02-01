using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCmpDouble : KnowledgeDecorator
{
    string key;
    string key2;

    /// <summary>
    /// Compares two custom knowledge values.
    /// Succeeds if values are identical, otherwise fails.
    /// </summary>
    /// <param name="_klg">Knowledge reference.</param>
    /// <param name="_key">Key/name of the first custom knowledge to compare.</param>
    /// <param name="_key2">Key/name of the second custom knowledge to compare.</param>
    /// <param name="_isNot">Fails if values are identical, otherwise succeeds.</param>
    public KnowledgeCmpDouble(Knowledge _klg, string _key, string _key2, bool _isNot = false)
        : base(_klg, _isNot)
    {
        key = _key;
        key2 = _key2;
    }

    public override NodeState Tick()
    {
        Knowledge knowledge = (Knowledge)agentKnowledge;
        // Check if knowledge can && does contain custom knowledges && check if the values have the same type and value
        if (knowledge.HasKnowledge(key) && knowledge.HasKnowledge(key2)
            && knowledge.GetKnowledge(key) == knowledge.GetKnowledge(key2))
        {
            if (isNot)
            {
                return NodeState.Failure;
            }
            return child.Tick();
        }
        else
        {
            if (isNot)
            {
                return child.Tick();
            }
            return NodeState.Failure;
        }
    }
}
