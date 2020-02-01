using UnityEngine;


[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/RepairableObject", order = 1)]
public class RepairableObject : ScriptableObject
{
    public Sprite[] images;
    public string name;
}
