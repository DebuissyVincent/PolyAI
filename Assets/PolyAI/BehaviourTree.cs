using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    private BTNode firstNode = null;

    public void Tick()
    {
        firstNode.Tick();
    }

    public void SetFirstNode(BTNode _node)
    {
        firstNode = _node;
    }
}
