using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyAgentBT : PolyAgentBase
{
    private BehaviourTree tree;

    protected override void Awake()
    {
        base.Awake();
        BTSetup setup = GetComponent<BTSetup>();
        setup.SetupTree(this);
    }

    public override void Tick()
    {
        tree.Tick();
    }

    public void SetBehaviourTree(BehaviourTree _bt)
    {
        tree = _bt;
    }
}
