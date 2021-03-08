using System;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public struct CustomKnowledge
//{
//    public Type type;
//    public object value;

//    public CustomKnowledge(Type _type)
//    {
//        type = _type;
//        value = null;
//    }
//}

[CreateAssetMenu(fileName = "Knowledge", menuName = "ScriptableObjects/Knowledge", order = 1)]
public class Knowledge : KnowledgeBase, ISerializationCallbackReceiver
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

    //public Type GetKnowledgeType(string _key)
    //{
    //    if (customKnowledge.ContainsKey(_key))
    //    {
    //        return customKnowledge[_key].type;
    //    }
    //    else
    //    {
    //        Debug.LogError("Tried to access non-existing custom knowledge");
    //    }
    //    return null;
    //}

    public void SetKnowledge<T>(string _key, T _value)
    {
        if (customKnowledge.ContainsKey(_key))
        {
            if (customKnowledge[_key] != null)
            {
                if ((T)customKnowledge[_key] != null)
                {
                    customKnowledge[_key] = _value;
                }
                else
                {
                    Debug.LogError("Retrieved custom knowledge has wrong type.");
                }
            }
        }
        else
        {
            Debug.LogError("Tried to access non-existing custom knowledge");
        }
    }

#if UNITY_EDITOR
    [HideInInspector]
    [SerializeField]
    public List<string> entries;

    // Dictionary to List to Inspector
    public void OnBeforeSerialize()
    {
        entries.Clear();
        foreach (string key in customKnowledge.Keys)
        {
            entries.Add(key);
        }
    }

    // List to Dictionary from Inspector
    public void OnAfterDeserialize()
    {
        customKnowledge.Clear();
        foreach (string entry in entries)
        {
            customKnowledge.Add(entry, null);
        }
    }

    //[System.Serializable]
    //public struct KnowledgeKey
    //{
    //    public string key;
    //    public Type type;

    //    public KnowledgeKey(string _key, Type _type)
    //    {
    //        key = _key;
    //        type = _type;
    //    }
    //}
#endif
}
