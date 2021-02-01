using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyAgentSimple : PolyAgentBase
{
    private Task task;

    private void Awake()
    {
        PolyAIManager.Instance.AddAgent(this);
        TaskSetup setup = GetComponent<TaskSetup>();
        task = setup.SetupTask();
    }

    private void Update()
    {
        if (timer <= 0.0f)
        {
            task.Tick();
            timer += interval;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
