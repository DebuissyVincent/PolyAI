using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyAgentSimple : PolyAgentBase
{
    private BTNode task;

    protected override void Awake()
    {
        base.Awake();
        TaskSetup setup = GetComponent<TaskSetup>();
        task = setup.SetupTask();
    }

    public override void Tick()
    {
        task.Tick();
    }
}
