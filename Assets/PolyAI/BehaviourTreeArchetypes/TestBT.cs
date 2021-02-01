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
        isAtPos.SetChild(new MoveTo(_agent, Vector3.zero));
        sequence.Child.Add(isAtPos);

        sequence.Child.Add(new Wait(0.5f));
        sequence.Child.Add(new Act(_agent, "Acting"));
        sequence.Child.Add(new Wait()); // By default, waits for 1 second

        Selector selector = new Selector();
        sequence.Child.Add(selector);

        // Begin Selector
        Sequence sequence2 = new Sequence();
        selector.Child.Add(sequence2);

        // Begin sequence 2
        IsAtPosition isAtPos2 = new IsAtPosition(_agent, Vector3.zero);
        isAtPos2.SetChild(new Act(_agent, "Acting"));
        sequence2.Child.Add(isAtPos2);

        sequence2.Child.Add(new MoveTo(_agent, Vector3.forward * 3.0f));
        // End sequence 2

        selector.Child.Add(new Wait(5.0f));
        // End selector
        // End sequence
    }
}
