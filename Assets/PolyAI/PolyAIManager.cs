using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyAIManager : MonoBehaviour
{
    static PolyAIManager instance = null;

    public static PolyAIManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = "PolyAIManager";
                instance = go.AddComponent<PolyAIManager>();
            }
            return instance;
        }
    }

    private List<PolyAgentBase> agents = new List<PolyAgentBase>();
    private List<ConstantUpdateNode> constantUpdateNodes = new List<ConstantUpdateNode>();
    private KnowledgeBase commonKlg;
    private PolyAgentBT alertedSimpleAI;

    public List<ConstantUpdateNode> ConstantUpdateNodes { get => constantUpdateNodes; }

    public void Start()
    {
        commonKlg = new KnowledgeBase();

        foreach (PolyAgentBase agent in agents)
        {
            agent.SetCommonKlg(commonKlg);
        }
    }

    public void Update()
    {
        foreach (ConstantUpdateNode node in constantUpdateNodes)
        {
            node.Update();
        }
    }

    public void AddAgent(PolyAgentBase _agent)
    {
        agents.Add(_agent);
    }
}
