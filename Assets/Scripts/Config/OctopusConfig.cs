using UnityEngine;

[CreateAssetMenu(fileName = "Octopus Config", menuName = "Config/Octopus Config",order =0)]
public class OctopusConfig : ScriptableObject
{
    [field: SerializeField] public float Speed;
}
