using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LogicGate
{
    And,
    Or,
    MAX
}

public struct ComplexPair
{
    LogicGate comparator;
    Decorator condition;
}

public class Complex : Decorator
{

    Decorator firstCondition;
    ComplexPair[] conditions;

    public override NodeState Tick()
    {
        return NodeState.Failure;
    }
}
