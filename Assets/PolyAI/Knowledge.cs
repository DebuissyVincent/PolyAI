using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CustomKnowledge
{
    public Type type;
    public object value;
}

[CreateAssetMenu(fileName = "Knowledge", menuName = "ScriptableObjects/Knowledge", order = 1)]
public class Knowledge : KnowledgeBase
{
    [SerializeField]
    private Dictionary<string, object> customKnowledge = new Dictionary<string, object>();

    public bool HasKnowledge(string _key)
    {
        return customKnowledge.ContainsKey(_key);
    }

    public object GetKnowledge(string _key)
    {
        if (customKnowledge.ContainsKey(_key))
        {
            return customKnowledge[_key];
        }
        else
        {
            Debug.LogError("Tried to access non-existing custom knowledge");
        }
        return null;
    }
}
