using UnityEngine;
using Zenject;

public class Bootstrup : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    private MessageBroker _messageBroker;

    [Inject]
    private void Install(MessageBroker messageBroker)
    {
        _messageBroker = messageBroker;
    }

    private void Start()
    {
        _messageBroker.Publish(new SceneMessage(_sceneName));
    }
}
