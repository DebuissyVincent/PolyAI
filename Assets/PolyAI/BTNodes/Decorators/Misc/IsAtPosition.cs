using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IsAtPosition : AgentDecorator
{
    float minRange;
    float maxRange;
    Vector3 pos;
    Knowledge klg = null;
    string knowledgePos = "";

    /// <summary>
    /// Will check if agent has and is at nav mesh agent destination.
    /// </summary>
    /// <param name="_minRange"></param>
    /// <param name="_maxRange">By default, will use nev mesh stopping distance.</param>
    /// <param name="_isNot"></param>
    public IsAtPosition(PolyAgentBase _agent, float _maxRange = -1.0f, float _minRange = 0.0f, bool _isNot = false) : base(_agent, _isNot)
    {
        minRange = _minRange;
        maxRange = _maxRange;
        agent = _agent;
    }

    /// <summary>
    /// Will check if agent is at determined position.
    /// </summary>
    /// <param name="_pos">The determined position.</param>
    /// <param name="_minRange"></param>
    /// <param name="_maxRange"></param>
    /// <param name="_isNot"></param>
    public IsAtPosition(PolyAgentBase _agent, Vector3 _pos, float _maxRange = 0.0f, float _minRange = 0.0f, bool _isNot = false)
        : base(_agent, _isNot)
    {
        pos = _pos;
        minRange = _minRange;
        maxRange = _maxRange;
    }

    /// <summary>
    /// Will check if agent is at custom knowledge position.
    /// </summary>
    /// <param name="_knowledgePos">The kay/name of the custom knowledge position.</param>
    /// <param name="_maxRange"></param>
    /// <param name="_minRange"></param>
    /// <param name="_isNot"></param>
    public IsAtPosition(Knowledge _klg, string _knowledgePos, float _maxRange = 0.0f, float _minRange = 0.0f, bool _isNot = false)
        : base(null, _isNot)
    {
        knowledgePos = _knowledgePos;
        minRange = _minRange;
        maxRange = _maxRange;
        klg = _klg;
    }

    private void CheckDistance(Vector3 _pos, float _maxRange)
    {
        float distance = (_pos - agent.transform.position).magnitude;
        if (distance <= _maxRange && distance >= minRange)
        {
            state = child.Tick();
        }
        else
        {
            Debug.Log("Is not at pos");
            state = NodeState.Failure;
        }
    }

    public override NodeState Tick()
    {
        if (agent != null)
        {
            NavMeshAgent nav = agent.GetComponent<NavMeshAgent>();
            if (maxRange < 0.0f)
            {
                CheckDistance(nav.destination, nav.stoppingDistance);
            }
            else
            {
                CheckDistance(nav.destination, maxRange);
            }
        }
        else if (klg != null)
        {
            if (klg.HasKnowledge(knowledgePos))
            {
                pos = (Vector3)klg.GetKnowledge(knowledgePos);
                if (pos != null)
                {
                    CheckDistance(pos, maxRange);
                }
                else
                {
                    Debug.LogError("Custom knowledge is not Vector3");
                    state = NodeState.Failure;
                }
            }
            else
            {
                state = NodeState.Failure;
            }

        }
        else
        {
            CheckDistance(pos, maxRange);
        }

        return state;
    }
}
