using UnityEngine;

[System.Serializable]
public struct CustomKnowledge
{
    public string key;
    public object value;
}

[CreateAssetMenu(fileName = "Knowledge", menuName = "ScriptableObjects/Knowledge", order = 1)]
public class Knowledge : KnowledgeBase
{
    [SerializeField]
    private CustomKnowledge[] customKnowledge = null;

    public CustomKnowledge[] CustomKnowledge { get => customKnowledge; }
}
