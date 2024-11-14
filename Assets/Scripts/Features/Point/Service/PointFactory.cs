using UnityEngine;
using Zenject;

public class PointFactory : IFactory<Transform, PointView>
{
    private PointView _viewPrefab;
    private AssetLoadService _assetLoadService;
    private DiContainer _container;

    public PointFactory(AssetLoadService assetLoadService, DiContainer container)
    {
        _assetLoadService = assetLoadService;
        _container = container;
        LoadPrefab();
    }

   
    public PointView Create(Transform parent)
    {
        return _container.InstantiatePrefabForComponent<PointView>(_viewPrefab, parent);
    }

    private async void LoadPrefab()
    {
        var gameObject = await _assetLoadService.LoadAsset<GameObject>(PointConstant.PointAssetKey);
        _viewPrefab = gameObject.GetComponent<PointView>();
    }
}
