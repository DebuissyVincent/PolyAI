using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRandomPos : Task
{
    public ChangeRandomPos(PolyAgentBase _agent) : base(_agent)
    {
    }

    public override NodeState Tick()
    {
        Knowledge klg = (Knowledge)agent.Knowledge;
        klg.SetKnowledge("RandomPos", new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, Random.Range(-20.0f, 20.0f)));
        Debug.Log((Vector3)klg.GetKnowledge("RandomPos"));
        return NodeState.Success;
    }
}
