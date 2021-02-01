using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AgentDecorator : Decorator
{
    protected PolyAgentBase agent;

    public AgentDecorator(PolyAgentBase _agent, bool _isNot) : base (_isNot)
    {
        agent = _agent;
    }
}
