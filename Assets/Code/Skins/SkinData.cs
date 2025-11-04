using UnityEngine;

[CreateAssetMenu(fileName = "SkinData", menuName = "Scriptable Objects/SkinData")]
public class SkinData : ScriptableObject
{
    public SkinType skinType;
    public string skinName;
    public Sprite sprite;
}
