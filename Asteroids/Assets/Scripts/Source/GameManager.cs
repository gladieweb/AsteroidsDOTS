using System;
using System.Collections;
using System.Collections.Generic;
using Dots;
using Dots.Data;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Events;
using Utility;

namespace Source
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject shipPrefab;
        public GameObject asteroidPrefab;

        private EntityManager _entityManager;
        private Entity _shipEntityPrefab;

        public static int AsteroidsToDestroy = 0;
        public static bool StartGame = true;

        // Start is called before the first frame update
        private void Start()
        {
            ConvertToEntitySystem convertToEntitySystem = World.DefaultGameObjectInjectionWorld.GetExistingSystem<ConvertToEntitySystem>();
            GameObjectConversionSettings settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, convertToEntitySystem.BlobAssetStore);
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _shipEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(shipPrefab, settings);
            //_asteroidEntityPrefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(asteroidPrefab, settings);
            this.Wait(0.2f, SpawnShip);
        }

        private new void OnDestroy()
        {
        }
        private void SpawnShip()
        {
            var ship = _entityManager.Instantiate(_shipEntityPrefab);
        }
    }
}
