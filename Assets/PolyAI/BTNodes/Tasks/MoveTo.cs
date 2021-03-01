using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : Task
{
    private Vector3 destination;
    private float minRange;
    private float maxRange;

    /// If _maxRange < 0.0f, will keep default nav mesh agent stopping distance.
    public MoveTo(PolyAgentBase _agent, Vector3 _destination, float _minRange = 0.0f, float _maxRange = -1.0f) : base(_agent)
    {
        destination = _destination;
        maxRange = _maxRange;
        minRange = _minRange;
    }

    public MoveTo(PolyAgentBase _agent, string _destinationKlg, float _minRange = 0.0f, float _maxRange = -1.0f) : base(_agent)
    {
        Knowledge klg = (Knowledge)agent.Knowledge;
        if (klg != null)
        {
            Vector3 dest = (Vector3)klg.GetKnowledge(_destinationKlg);
            if (dest != null)
            {
                destination = dest;
            }
            else
            {
                Debug.LogError("Retrieved custom knowledge has wrong type.");
            }
        }
        else
        {
            Debug.LogError("Tried using custom knowledge with KnowledgeBase.");
        } 
        maxRange = _maxRange;
        minRange = _minRange;
    }

    public override NodeState Tick()
    {
        NavMeshAgent nav = agent.GetComponent<NavMeshAgent>();
        // Path is not available or must be updated
        if ((!nav.hasPath && !nav.pathPending) || nav.destination != destination)
        {
            // Path can be done
            if (nav.SetDestination(destination))
            {
                if (maxRange >= 0.0f)
                {
                    nav.stoppingDistance = maxRange;
                }
                state = NodeState.Running;
                Debug.Log("Moving to " + destination.ToString());
            }
            // Path cannot be done
            else
            {
                Debug.Log("Can't move to " + destination.ToString());
                state = NodeState.Failure;
            }
        }
        // Path already set
        else
        {
            // Agent is closest to destination as can be
            if (nav.remainingDistance <= minRange)
            {
                nav.isStopped = true;
                state = NodeState.Success;
                Debug.Log("Moving stoped. Agent as close as need be.");
            }
            // Agent is at destination
            else if (nav.remainingDistance <= nav.stoppingDistance)
            {
                if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                {
                    state = NodeState.Success;
                    Debug.Log("Moving stoped. Agent is close enough.");
                }
            }
        }
        return NodeState.Success;
    }
}
