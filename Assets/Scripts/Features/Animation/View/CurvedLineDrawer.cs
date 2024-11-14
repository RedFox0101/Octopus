using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CurvedLineDrawer : MonoBehaviour
{
    [SerializeField] private int _segmentCount = 20;

    private LineRenderer _lineRenderer;


    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

    }

    public void DrawCurvedLine(Vector3 currentPosition, Vector3 targetPosition)
    {
        Vector3 startPosition = currentPosition;


        Vector3 controlPoint1 = startPosition + Vector3.up * 2f + Vector3.right * 2f;
        Vector3 controlPoint2 = targetPosition + Vector3.up * 2f - Vector3.right * 2f;


        _lineRenderer.positionCount = _segmentCount;
        for (int i = 0; i < _segmentCount; i++)
        {
            float t = i / (_segmentCount - 1f);
            Vector3 pointOnCurve = CalculateBezierPoint(t, startPosition, controlPoint1, controlPoint2, targetPosition);
            _lineRenderer.SetPosition(i, pointOnCurve);
        }
     
    }

    private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;

        return p;
    }
}
