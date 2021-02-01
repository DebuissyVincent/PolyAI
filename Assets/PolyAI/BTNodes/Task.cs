using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : BTNode
{
    protected PolyAgentBase agent;

    protected Task(PolyAgentBase _agent)
    {
        agent = _agent;
    }
}
