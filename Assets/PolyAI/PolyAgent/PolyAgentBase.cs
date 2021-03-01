using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PolyAgentBase : MonoBehaviour
{
    //public abstract bool Interact();

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
}
