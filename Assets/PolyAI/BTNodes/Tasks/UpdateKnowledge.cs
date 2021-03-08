using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UpdateKnowledge : Task
{
    string key;
    bool common;

    public UpdateKnowledge(PolyAgentBase _agent, string _key, bool _common = false) : base(_agent)
    {
        key = _key;
        common = _common;
    }

    public override NodeState Tick()
    {
        Knowledge klg = (Knowledge)agent.Knowledge;
        if (klg != null)
        {
            if (klg.HasKnowledge(key))
            {
                ApplyValues();
            }
            else
            {
                Debug.LogError("Custom knowledge doesn't exist");
            }
        }
        else
        {
            Debug.LogError("Tried using custom knowledge with KnowledgeBase.");
        }

        return NodeState.Success;
    }

    public abstract void ApplyValues();
}
