using UniRx;

public class OctopusInitializationService 
{
    private OctopusFactory _octopusFactory;
    private MessageBroker _messageBroker;
    private CompositeDisposable _compositeDisposable;

    private OctopusView _octopusView;

    public OctopusView OctopusView  => _octopusView; 

    public OctopusInitializationService(OctopusFactory octopusFactory, MessageBroker messageBroker)
    {
        _octopusFactory = octopusFactory;
        _messageBroker = messageBroker;
        _compositeDisposable= new CompositeDisposable();
        SubscribeToOctopusSetupMessage();
    }

    private void SubscribeToOctopusSetupMessage()
    {
        _messageBroker.Receive<OctopusSpawnMessage>()
            .Subscribe(msg =>
            {
                SpawnOctopus();
            }).AddTo(_compositeDisposable);
    }

    private void SpawnOctopus()
    {
        _octopusView = _octopusFactory.Create();
    }
}
