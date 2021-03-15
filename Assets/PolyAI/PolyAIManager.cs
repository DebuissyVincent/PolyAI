using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyAIManager : MonoBehaviour
{
    static PolyAIManager instance = null;

    public static PolyAIManager Instance()
    {
        if (instance == null)
        {
            GameObject go = new GameObject();
            go.name = "PolyAIManager";
            instance = go.AddComponent<PolyAIManager>();
        }
        return instance;
    }

    private List<PolyAgentBase> agents = new List<PolyAgentBase>();
    private LinkedList<PolyAgentBase> agentsToTick = new LinkedList<PolyAgentBase>();
    private List<ConstantUpdateNode> constantUpdateNodes = new List<ConstantUpdateNode>();
    private PolyAgentBT alertedSimpleAI;
    [SerializeField]
    private short agentsPerFrame = 10;
    private short maxAgentsToTick = 200;

    public List<ConstantUpdateNode> ConstantUpdateNodes { get => constantUpdateNodes; }

    public void Update()
    {
        // Update agents intervals
        foreach (PolyAgentBase agent in agents)
        {
            agent.UpdateTick();
        }
        // Tick agents to be ticked
        for (int i = 0; i < (agentsToTick.Count < agentsPerFrame ? agentsToTick.Count : agentsPerFrame); i++)
        {
            agentsToTick.First.Value.Tick();
            agentsToTick.RemoveFirst();
        }
        foreach (ConstantUpdateNode node in constantUpdateNodes)
        {
            node.Update();
        }
    }

    public void AddAgent(PolyAgentBase _agent)
    {
        agents.Add(_agent);
    }

    public void RequestTick(PolyAgentBase _agent)
    {
        if (_agent == agents[0])
        {
            if (agentsToTick.Count > 0)
            {
                agentsPerFrame++;
            }
            else if (agentsPerFrame > 1)
            {
                agentsPerFrame--;
            }
        }
        agentsToTick.AddLast(_agent);
    }
}
