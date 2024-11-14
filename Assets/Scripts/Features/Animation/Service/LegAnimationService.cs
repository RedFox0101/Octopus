using UniRx;

public class LegAnimationService
{
    private OctopusInitializationService _initializationService;
    private PointService _pointService;
    private MessageBroker _messageBroker;
    private CompositeDisposable _compositeDisposable;

    public LegAnimationService(OctopusInitializationService initializationService, PointService pointService, MessageBroker messageBroker)
    {
        _compositeDisposable = new CompositeDisposable();
        _initializationService = initializationService;
        _pointService = pointService;
        _messageBroker = messageBroker;
        SubscribeToStartMovingMessage();
    }

    private void SubscribeToStartMovingMessage()
    {
        _messageBroker.Receive<OctopusMovingMessage>()
            .Subscribe(msg =>
            {
                StartUpdateLegAnimation();
            }).AddTo(_compositeDisposable);
    }

    private void StartUpdateLegAnimation()
    {
        var octopus = _initializationService.OctopusView;

        var points = _pointService.Get(octopus.transform.position);

        octopus.UpdateLegs(points);
    }
}
