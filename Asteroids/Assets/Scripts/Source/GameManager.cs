using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Utility;

public class GameManager : Singleton<GameManager>
{
    public GameObject shipPrefab;
    private EntityManager _entityManager;
    private Entity _shipEntityPrefab;
     
    // Start is called before the first frame update
    private void Start()
    {
        ConvertToEntitySystem convertToEntitySystem = World.DefaultGameObjectInjectionWorld.GetExistingSystem<ConvertToEntitySystem>();
        GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, convertToEntitySystem.BlobAssetStore);
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        _shipEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(shipPrefab, settings);
        
        SpawnAsteroids();
        this.Wait(1, SpawnShip);
    }

    private new void OnDestroy()
    {
    }
    // ReSharper disable Unity.PerformanceAnalysis
    private void SpawnShip()
    {
        var ship = _entityManager.Instantiate(_shipEntityPrefab);
    }

    private void SpawnAsteroids()
    {
    }
}
