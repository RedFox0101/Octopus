using Assets.Scripts.Infrastructure;
using Zenject;

public class InputFeatureInitCommand : BaseFeatureInitCommand
{
    public override void BindDependencies(DiContainer DiContainer)
    {
        DiContainer.BindInterfacesAndSelfTo<MouseInputService>().AsSingle().NonLazy();
    }
}
