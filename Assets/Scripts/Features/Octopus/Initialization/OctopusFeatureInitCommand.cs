using Assets.Scripts.Infrastructure;
using Zenject;

public class OctopusFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<OctopusFactory>().AsSingle().NonLazy();
        DiContainer.BindInterfacesAndSelfTo<OctopusInitializationService>().AsSingle().NonLazy();
        DiContainer.BindInterfacesAndSelfTo<OctopusMovingService>().AsSingle().NonLazy();
    }
}
