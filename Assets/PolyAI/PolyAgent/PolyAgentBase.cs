using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PolyAgentBase : MonoBehaviour
{
    //public abstract bool Interact();

    protected bool isActivated = false;
    protected List<Sensor> sensors = new List<Sensor>();
    protected KnowledgeBase commonKlg;
    protected KnowledgeBase privateKlg;
    [SerializeField]
    protected float interval = 0.5f;
    protected float timer = 0.0f;

    public void SetCommonKlg(KnowledgeBase _knowledge)
    {
        commonKlg = _knowledge;
    }

    public void SetPrivateKlg(KnowledgeBase _knowledge)
    {
        commonKlg = _knowledge;
    }
}
