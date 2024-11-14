using Assets.Scripts.Infrastructure;
using Zenject;

public class PointFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<PointFactory>().AsSingle().NonLazy();
        DiContainer.BindInterfacesAndSelfTo<PointService>().AsSingle().NonLazy();
    }
}
