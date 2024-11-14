using UnityEngine;

[CreateAssetMenu(fileName = "PointConfig", menuName = "Config/PointConfig", order =0)]
public class PointConfig : ScriptableObject
{
    [field: SerializeField] public int NumberPoins;

}
