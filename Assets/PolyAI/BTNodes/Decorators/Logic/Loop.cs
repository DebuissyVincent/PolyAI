using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : Decorator, ConstantUpdateNode
{
    int nb;
    int counter;
    bool isInfinite;
    float infiniteTimeoutTime;
    float timer;
    bool untilChildIsDone;

    public Loop(int _nb, bool _untilChildIsDone = false, bool _isNot = false) : base(_isNot)
    {
        nb = _nb;
        isInfinite = false;
        untilChildIsDone = _untilChildIsDone;
        counter = nb;
    }

    public Loop(float _infiniteTimeoutTime, bool _untilChildIsDone = false, bool _isNot = false) : base(_isNot)
    {
        isInfinite = true;
        infiniteTimeoutTime = _infiniteTimeoutTime;
        untilChildIsDone = _untilChildIsDone;
        timer = infiniteTimeoutTime;
    }

    public void Update()
    {
        if (isInfinite && timer > 0.0f)
        {
            timer -= Time.deltaTime;
        }
    }

    public override NodeState Tick()
    {
        if (isInfinite)
        {
            if (timer <= 0.0f)
            {
                state = NodeState.Failure;
                timer = infiniteTimeoutTime;
            }
            else
            {
                state = child.Tick();
                if (!untilChildIsDone)
                {
                    state = NodeState.Running;
                }
            }
        }
        else
        {
            if (counter > 0)
            {
                state = NodeState.Failure;
                counter = nb;
            }
            else
            {
                state = child.Tick();
                if (!untilChildIsDone)
                {
                    state = NodeState.Running;
                }
            }
        }
        return NodeState.Failure;
    }
}
