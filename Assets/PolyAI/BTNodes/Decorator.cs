using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : BTNode
{
    protected BTNode child;
    protected bool isNot;

    protected Decorator(bool _isNot)
    {
        isNot = _isNot;
    }

    public BTNode Child { get => child; }

    public void SetChild(BTNode _child)
    {
        child = _child;
    }
}
