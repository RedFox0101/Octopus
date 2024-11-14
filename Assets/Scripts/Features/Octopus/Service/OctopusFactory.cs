using UnityEngine;
using Zenject;

public class OctopusFactory : IFactory<OctopusView>
{
    private AssetLoadService _assetLoadService;
    private DiContainer _container;

    private OctopusView _octopusViewPrefab;

    public OctopusFactory(AssetLoadService assetLoadService, DiContainer container)
    {
        _assetLoadService = assetLoadService;
        _container = container;
        LoadPrefab();
    }

    public OctopusView Create()
    {
        return _container.InstantiatePrefabForComponent<OctopusView>(_octopusViewPrefab);
    }

    private async void LoadPrefab()
    {
        var gameObject = await _assetLoadService.LoadAsset<GameObject>(OctopusConstant.OctopusAsset);
        _octopusViewPrefab = gameObject.GetComponent<OctopusView>();
    }
}
