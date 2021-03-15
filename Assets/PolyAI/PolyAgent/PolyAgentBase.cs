using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PolyAgentBase : MonoBehaviour
{
    PolyAIManager AIManager;

    protected bool isActivated = false;
    protected KnowledgeBase knowledge;
    [SerializeField]
    protected float interval = 0.5f;
    protected float timer = 0.0f;

    public KnowledgeBase Knowledge { get => knowledge; }

    public void SetPrivateKlg(KnowledgeBase _knowledge)
    {
        knowledge = _knowledge;
    }

    protected virtual void Awake()
    {
        AIManager = PolyAIManager.Instance();
        AIManager.AddAgent(this);
    }

    public void UpdateTick()
    {
        if (timer <= 0.0f)
        {
            AIManager.RequestTick(this);
            timer += interval;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public abstract void Tick();
}
