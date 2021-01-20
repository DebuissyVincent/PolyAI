using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : ConstantUpdateNode
{
    private float duration;
    private float timer;

    public Wait(float _duration = 1.0f)
    {
        duration = _duration;
        PolyAIManager.Instance.ConstantUpdateNodes.Add(this);
    }

    public override void Update()
    {
        timer -= Time.deltaTime;
    }

    public override NodeState Tick()
    {
        if (state != NodeState.Running)
        {
            Debug.Log("Waiting");
            timer = duration;
            needsUpdate = true;
            state = NodeState.Running;
        }
        // When duration is 0.0f, waits for one frame.
        else
        {
            if (timer <= 0.0f)
            {
                needsUpdate = false;
                state = NodeState.Success;
            }
        }
        return state;
    }
}
