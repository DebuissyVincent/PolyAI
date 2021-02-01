using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSetup : TaskSetup
{
    [SerializeField] private Vector3 destination = Vector3.zero;
    [SerializeField] private float minRange = 0.0f;
    [SerializeField] private float maxRange = -1.0f;

    public override Task SetupTask()
    {
        MoveTo task = new MoveTo(GetComponent<PolyAgentBase>(), destination, minRange, maxRange);
        return task;
    }
}
