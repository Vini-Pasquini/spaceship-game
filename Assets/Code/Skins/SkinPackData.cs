using UnityEngine;

[CreateAssetMenu(fileName = "SkinPackData", menuName = "Scriptable Objects/SkinPackData")]
public class SkinPackData : ScriptableObject
{
    public SkinData playerShip;

    public SkinData enemyShip;
}
