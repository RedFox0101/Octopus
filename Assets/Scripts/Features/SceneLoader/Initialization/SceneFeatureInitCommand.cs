using Assets.Scripts.Infrastructure;
using Zenject;

namespace Assets.Scripts.Features.SceneLoader
{
    public class SceneFeatureInitCommand : BaseFeatureInitCommand
    {
        public override void BindDependencies(DiContainer DiContainer)
        {
            DiContainer.BindInterfacesAndSelfTo<SceneLoadService>().AsSingle().NonLazy();
        }
    }
}