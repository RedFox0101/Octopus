using UnityEngine;

public class OctopusView : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    public void MoveToTarget(Vector3 targetPosition)
    {
        targetPosition.z = 0;
        transform.position=(targetPosition);
    }
}
