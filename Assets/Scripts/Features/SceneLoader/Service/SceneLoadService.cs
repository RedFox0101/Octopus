using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadService
{
    private MessageBroker _messageBroker;
    private CompositeDisposable _disposables;

    public SceneLoadService(MessageBroker messageBroler)
    {
        _disposables = new CompositeDisposable();
        _messageBroker = messageBroler;
        SubscribeToSceneMessagesMessages();
    }

    private void SubscribeToSceneMessagesMessages()
    {
        _messageBroker.Receive<SceneMessage>()
           .Subscribe(msg =>
           {
               LoadScene(msg.SceneName);
           }).AddTo(_disposables);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName)
           .AsAsyncOperationObservable()
           .Subscribe(_ =>
             {
               Debug.Log($"{sceneName} loaded");
             }).AddTo(_disposables);
    }
}
