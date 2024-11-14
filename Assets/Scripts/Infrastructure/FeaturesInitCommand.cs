using Assets.Scripts.Features.SceneLoader;
using Zenject;

namespace Assets.Scripts.Infrastructure
{
    public class FeaturesInitCommand
    {
        private InitializationCommandExecutor _initializationCommandExecutor;

        public FeaturesInitCommand(DiContainer diContainer)
        {
            _initializationCommandExecutor = new InitializationCommandExecutor(diContainer);
            CreateInitializationPipe();
        }

        private void CreateInitializationPipe()
        {
            _initializationCommandExecutor.Add<MessageFeatureInitCommand>();
            _initializationCommandExecutor.Add<AssetFeatureInitCommand>();
            _initializationCommandExecutor.Add<SceneFeatureInitCommand>();
            _initializationCommandExecutor.Add<PointFeatureInitCommand>();
        }
    }
}