using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : BTNode
{
    private Vector3 destination;
    private float minRange;
    private float maxRange;

    public override NodeState Tick()
    {
        Debug.Log("Moving to : " + destination.ToString());
        return NodeState.Success;
    }

    public void SetDestination(Vector3 _dest)
    {
        destination = _dest;
    }

    public void SetMinRange(float _range)
    {
        minRange = _range;
    }

    public void SetMaxRange(float _range)
    {
        maxRange = _range;
    }
}
