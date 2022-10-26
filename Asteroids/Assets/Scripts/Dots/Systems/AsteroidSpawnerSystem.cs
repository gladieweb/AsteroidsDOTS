using Dots.Data;
using Dots.Tags.Actions;
using Dots.Tags.Objects;
using Source;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Dots.Systems
{
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    public class AsteroidSpawnerSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _endSimulationEntityCommandBufferSystem;
        //private BufferLookup<ExampleBufferComponent> _bufferLookup;
        protected override void OnCreate()
        {
            base.OnCreate();
            _endSimulationEntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }
        
       
        protected override void OnUpdate()
        {
            var ecb = _endSimulationEntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
            var prefabData = GetSingleton<AsteroidPrefabData>();
            var asteroidSpawnerEntity = prefabData.buffer;
            //var myBuffer = EntityManager.GetBuffer<AsteroidsBufferElement>(asteroidSpawnerEntity).ToNativeArray(Allocator.TempJob);
            var job = Entities
                .ForEach((Entity entity, int entityInQueryIndex, AsteroidSpawnerData spawnerData) =>
                    {
                      /*if (spawnerData.AsteroidsToSpawn > 0)
                        {
                            spawnerData.AsteroidsToSpawn--;
                            var rnd= Random.CreateFromIndex((uint)entityInQueryIndex);
                            var angle = rnd.NextInt(1, 360);
                            var dir = math.right() * math.cos(angle);
    
                            var direction = dir;
                            var pref = spawnerData.generation == 0 ? prefabData.asteroidPrefab0 :
                                spawnerData.generation == 1 ? prefabData.asteroidPrefab1 : prefabData.asteroidPrefab2;
                            var asteroid = ecb.Instantiate(entityInQueryIndex, pref);
                            //var asteroidBufferData = myBuffer[spawnerData.generation];
                            ecb.SetComponent(entityInQueryIndex, asteroid,
                                new AsteroidData { asteroidGeneration = spawnerData.generation });
                            ecb.SetComponent(entityInQueryIndex, asteroid,
                                new SimpleMoveData { Speed = 250, Direction = direction });
                            ecb.SetComponent(entityInQueryIndex, asteroid,
                                new Scale { Value = 160 });
                            GameManager.AsteroidsToDestroy++;
                            if (spawnerData.AsteroidsToSpawn <= 0)
                            {
                                ecb.RemoveComponent<AsteroidSpawnerData>(entityInQueryIndex, entity);
                            }
                        }*/
                    }
                ).ScheduleParallel(this.Dependency);
            _endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(job);
            this.Dependency = job;
        }
    }
}
