using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KnowledgeDecorator : Decorator
{
    protected KnowledgeBase agentKnowledge;

    protected KnowledgeDecorator(KnowledgeBase _agentKnowledge, bool _isNot) : base(_isNot)
    {
        agentKnowledge = _agentKnowledge;
    }
}
