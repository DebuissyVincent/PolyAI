using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyAgentBT : PolyAgentBase
{
    private BehaviourTree tree;

    public void Awake()
    {
        PolyAIManager.Instance.AddAgent(this);
        BTSetup setup = GetComponent<BTSetup>();
        setup.SetupTree(this);
    }

    private void Update()
    {
        if (timer <= 0.0f)
        {
            tree.Tick();
            timer += interval;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void SetBehaviourTree(BehaviourTree _bt)
    {
        tree = _bt;
    }
}
