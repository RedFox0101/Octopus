using UnityEngine;
using Zenject;

public class ConfigMonoInstaller : MonoInstaller
{
    [SerializeField] private PointConfig _config;

    public override void InstallBindings()
    {
        Container.Bind<PointConfig>().FromInstance(_config).AsSingle();
    }
}
