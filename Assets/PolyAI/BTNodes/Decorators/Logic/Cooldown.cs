using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : Decorator
{
    float time;
    float timer;

    public Cooldown(bool _isNot = false) : base(_isNot)
    {
    }

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
