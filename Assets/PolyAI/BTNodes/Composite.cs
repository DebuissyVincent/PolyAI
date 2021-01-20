using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Composite : BTNode
{
    protected List<BTNode> child = new List<BTNode>();
    protected int lastRunning = 0;
    [SerializeField]
    private bool isRandom = false;

    public List<BTNode> Child { get => child; }
    protected bool IsRandom { get => isRandom;}
}
