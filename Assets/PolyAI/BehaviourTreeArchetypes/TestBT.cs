using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBT : BTSetup
{
    public override void BuildTree(BehaviourTree _bt, PolyAgentBT _agent)
    {
        Sequence sequence = new Sequence(true); // By default, the sequence won't break upon the failure of his children
        _bt.SetFirstNode(sequence);

        // Begin sequence
        IsAtPosition isAtPos = new IsAtPosition(_agent); // Check for nav agent destination
        isAtPos.SetChild(new MoveTo(_agent, transform.position + new Vector3(5.0f, 0.0f, 8.0f)));
        sequence.Child.Add(isAtPos);

        IsAtPosition isAtPos2 = new IsAtPosition(_agent);
        isAtPos2.SetChild(new Act(_agent, "Acting"));
        sequence.Child.Add(isAtPos2);

        IsAtPosition isAtPos3 = new IsAtPosition(_agent);
        isAtPos3.SetChild(new MoveTo(_agent, transform.position - new Vector3(5.0f, 0.0f, 8.0f)));
        sequence.Child.Add(isAtPos3);

        IsAtPosition isAtPos4 = new IsAtPosition(_agent);
        isAtPos4.SetChild(new Act(_agent, "Acting"));
        sequence.Child.Add(isAtPos4);

        sequence.Child.Add(new Wait()); // By default, waits for 1 second
        // End sequence
    }
}
