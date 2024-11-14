using UnityEngine;
using Zenject;

public class ConfigMonoInstaller : MonoInstaller
{
    [SerializeField] private PointConfig _pointConfig;
    [SerializeField] private OctopusConfig _opusConfig;
    public override void InstallBindings()
    {
        Container.Bind<PointConfig>().FromInstance(_pointConfig).AsSingle();
        Container.Bind<OctopusConfig>().FromInstance(_opusConfig).AsSingle();   
    }
}
