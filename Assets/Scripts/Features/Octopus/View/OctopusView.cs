using System.Collections.Generic;
using UnityEngine;

public class OctopusView : MonoBehaviour
{
    [SerializeField] private List<CurvedLineDrawer> _curvedLineDrawers;
    [SerializeField] private OctopusConfig _octopusConfig;
    public List<CurvedLineDrawer> CurvedLineDrawers => _curvedLineDrawers; 

    public void MoveToTarget(Vector3 targetPosition)
    {
        targetPosition.z = 0;
        transform.position=(targetPosition);
    }

    public void UpdateLegs(List<Vector3> targetPoints)
    {
        for (int i = 0; i < _curvedLineDrawers.Count; i++)
        {
            _curvedLineDrawers[i].DrawCurvedLine(transform.position, targetPoints[i], _octopusConfig.CurvatureFactor);
        }   
    }
}
