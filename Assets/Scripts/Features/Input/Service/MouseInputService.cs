using UniRx;
using UnityEngine;

public class MouseInputService
{
    private MessageBroker _messageBroker;
    private CompositeDisposable _compositeDisposable;
    private Camera _camera;

    public MouseInputService(MessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
        _compositeDisposable= new CompositeDisposable();
        SubscribeToStartMovingMessage();
    }

    private void SubscribeToStartMovingMessage()
    {
        _camera = Camera.main;
        _messageBroker.Receive<StartInputMessage>()
            .Subscribe(msg =>
            {
                StartTrackingInput();
            }).AddTo(_compositeDisposable);
    }

    private void StartTrackingInput()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetMouseButton(0))
            {
                var targetPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _messageBroker.Publish(new OctopusMovingMessage(targetPosition));
            }
        }).AddTo(_compositeDisposable);
    }
}
