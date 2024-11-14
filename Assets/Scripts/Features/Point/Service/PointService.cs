using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PointService 
{
    private MessageBroker _messageBroker;
    private PointFactory _pointFactory;
    private PointConfig _pointConfig;

    private CompositeDisposable _compositeDisposable;

    private List<PointView> _viewList;
    public PointService(MessageBroker messageBroker, PointFactory pointFactory, PointConfig pointConfig)
    {
        _messageBroker = messageBroker;
        _pointFactory = pointFactory;
        _pointConfig = pointConfig;
        _compositeDisposable = new CompositeDisposable();
        _viewList = new List<PointView>();
        SubscribeToSceneSpawnPoints();
    }

    private void SubscribeToSceneSpawnPoints()
    {
        _messageBroker.Receive<PointMessage>()
           .Subscribe(msg =>
           {
               SpawnPoints(msg.Parent);
           }).AddTo(_compositeDisposable);
    }

    private  void SpawnPoints(Transform parent)
    {
        var camera= Camera.main;
        _viewList.Clear();
        Vector2 min = camera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = camera.ViewportToWorldPoint(new Vector2(1, 1));

        for (int i = 0; i < _pointConfig.NumberPoins; i++)
        {
            Vector3 randomPosition = GetRandomPositionInBounds(min, max);

            var point =  _pointFactory.Create(parent);
            point.transform.position = randomPosition;
            _viewList.Add(point);
        }
    }

    private static Vector3 GetRandomPositionInBounds(Vector2 min, Vector2 max)
    {
        float randomX = Random.Range(min.x, max.x);
        float randomY = Random.Range(min.y, max.y);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0);
        return randomPosition;
    }
}