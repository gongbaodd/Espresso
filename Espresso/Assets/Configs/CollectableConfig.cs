
using UnityEngine;

public enum CollectableType
{
    Sugar,
    Milk,
    Salt,
    Mucus,
}

[CreateAssetMenu(fileName = "CollectableConfig", menuName = "Configs/CollectableConfig", order = 1)]
public class CollectableConfig : ScriptableObject
{
    public CollectableType collectableType;
}
