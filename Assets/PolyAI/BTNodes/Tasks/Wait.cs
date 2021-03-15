using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : BTNode, ConstantUpdateNode
{
    private float duration;
    private float timer;
    //private bool forceTickUponEnd;

    public Wait(float _duration = 1.0f)
    {
        duration = _duration;
        //forceTickUponEnd = _forceTickUponEnd;
        PolyAIManager.Instance().ConstantUpdateNodes.Add(this);
    }

    public void Update()
    {
        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
        //else if (forceTickUponEnd)
        //{
        //    return true;
        //}
        //return false;
    }

    public override NodeState Tick()
    {
        if (state != NodeState.Running)
        {
            timer = duration;
            state = NodeState.Running;
        }
        // When duration is 0.0f, waits for one-two frame.
        else
        {
            if (timer <= 0.0f)
            {
                state = NodeState.Success;
            }
        }
        return state;
    }
}
