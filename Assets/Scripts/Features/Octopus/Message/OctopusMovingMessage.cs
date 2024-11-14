using UnityEngine;

public class OctopusMovingMessage : MessageBase
{
    public readonly Vector3 TargetPosition;

    public OctopusMovingMessage(Vector3 targetPosition)
    {
        TargetPosition = targetPosition;
    }
}
