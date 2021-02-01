using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSetup : TaskSetup
{
    [SerializeField] private string action;

    public override Task SetupTask()
    {
        Task task = new Act(GetComponent<PolyAgentBase>(), action);
        return task;
    }
}
