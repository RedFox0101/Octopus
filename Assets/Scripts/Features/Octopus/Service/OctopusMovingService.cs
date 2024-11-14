using UniRx;
using UnityEngine;

public class OctopusMovingService
{
    private OctopusInitializationService _octopusInitializationService;
    private OctopusConfig _octopusConfig;
    private MessageBroker _messageBroker;

    private CompositeDisposable _compositeDisposable;

    public OctopusMovingService(OctopusInitializationService octopusInitializationService, OctopusConfig octopusConfig, MessageBroker messageBroker)
    {
        _octopusInitializationService = octopusInitializationService;
        _octopusConfig = octopusConfig;
        _messageBroker = messageBroker;
        _compositeDisposable = new CompositeDisposable();
        SubscribeToMovingMessage();
    }

    private void SubscribeToMovingMessage()
    {
        _messageBroker.Receive<OctopusMovingMessage>().
            Subscribe(_msg =>
            {
                Move(_msg.TargetPosition);
            }).AddTo(_compositeDisposable);
    }

    private void Move(Vector3 targetPosition)
    {
        _octopusInitializationService.OctopusView.MoveToTarget(Vector3.MoveTowards(_octopusInitializationService.OctopusView.transform.position, targetPosition, _octopusConfig.Speed * Time.deltaTime));
    }
}
