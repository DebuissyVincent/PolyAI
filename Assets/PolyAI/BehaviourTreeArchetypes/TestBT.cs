using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBT : BTSetup
{
    public override void BuildTree(BehaviourTree _bt, KnowledgeBase _privateKlg)
    {
        Sequence sequence = new Sequence();

        _bt.SetFirstNode(sequence);

        sequence.Child.Add(new MoveTo());
        sequence.Child.Add(new Wait(0.5f));
        sequence.Child.Add(new Act());
        sequence.Child.Add(new Wait()); // By default, waits for 1 second

        Selector selector = new Selector();

        sequence.Child.Add(selector);

        ForceStatus forceStatus = new ForceStatus(NodeState.Failure);

        selector.Child.Add(forceStatus);

        forceStatus.SetChild(new MoveTo());

        selector.Child.Add(new Act());
        selector.Child.Add(new Wait(5.0f));
    }
}
