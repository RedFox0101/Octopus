using Assets.Scripts.Infrastructure;
using Zenject;

public class AssetFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<AssetLoadService>().AsSingle().NonLazy();
    }
}
