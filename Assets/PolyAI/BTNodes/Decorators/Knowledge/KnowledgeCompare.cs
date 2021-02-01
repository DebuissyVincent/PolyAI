using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeCompare : KnowledgeDecorator
{
    string key;
    object value;

    /// <summary>
    /// Compares a custom knowledge value and a defined value.
    /// Succeeds if values are identical, otherwise fails.
    /// </summary>
    /// <param name="_klg">Knowledge reference.</param>
    /// <param name="_key">Key/name of the custom knowledge to compare.</param>
    /// <param name="_value">Defined value to compare.</param>
    /// <param name="_isNot">Fails if values are identical, otherwise succeeds.</param>
    public KnowledgeCompare(Knowledge _klg, string _key, object _value, bool _isNot = false) : base(_klg, _isNot)
    {
        value = _value;
        key = _key;
    }

    public override NodeState Tick()
    {
        Knowledge knowledge = (Knowledge)agentKnowledge;
        // Check if knowledge can && does contain custom knowledge && check if the values have the same type and value
        if (knowledge.HasKnowledge(key) && value != null
            && knowledge.GetKnowledge(key) == value)
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
