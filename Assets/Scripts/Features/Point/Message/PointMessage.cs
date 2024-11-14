using UnityEngine;

public class PointMessage : MessageBase
{
    public readonly Transform Parent;

    public PointMessage(Transform parent)
    {
        Parent = parent;
    }
}
