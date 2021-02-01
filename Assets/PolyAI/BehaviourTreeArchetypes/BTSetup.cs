using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTSetup : MonoBehaviour
{
    [SerializeField] protected KnowledgeBase privateKlg = null;

    public void SetupTree(PolyAgentBT _agent)
    {
        BehaviourTree bt = new BehaviourTree();

        BuildTree(bt, _agent);

        _agent.SetPrivateKlg(privateKlg);
        _agent.SetBehaviourTree(bt);
    }

    public abstract void BuildTree(BehaviourTree _bt, PolyAgentBT _agent);
}
