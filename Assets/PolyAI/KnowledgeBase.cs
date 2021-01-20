using UnityEngine;

public class KnowledgeBase : ScriptableObject
{
    [SerializeField]
    protected bool isAlert = false;
    
    public bool IsAlert { get => isAlert; }

    protected void SetAlert(bool _isAlert)
    {
        isAlert = _isAlert;
    }
}
