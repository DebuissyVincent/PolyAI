using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator : BTNode
{
    protected BTNode child = null;
    protected bool isNot;

    /// <summary>
    /// Basic Decorator constructor.
    /// </summary>
    /// <param name="_isNot">Will reverse some of the Decorator behaviours.</param>
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
