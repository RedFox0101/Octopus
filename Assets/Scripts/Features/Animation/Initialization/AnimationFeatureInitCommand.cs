using Assets.Scripts.Infrastructure;
using Zenject;

public class AnimationFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<LegAnimationService>().AsSingle().NonLazy();
    }
}
