using Dots.Data;
using Dots.Tags.Actions;
using Dots.Tags.Objects;
using Unity.Entities;
using UnityEngine;

namespace Dots.Systems
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public class WeaponSystem : SystemBase
    {
        private EndInitializationEntityCommandBufferSystem _endInitializationEntityCommandBufferSystem;
        protected override void OnCreate()
        {
            base.OnCreate();
            _endInitializationEntityCommandBufferSystem = World.GetOrCreateSystem<EndInitializationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var ecb = _endInitializationEntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
            //var spawnerQuery = EntityManager.CreateEntityQuery(typeof(WeaponCooldown), typeof(WeaponData));
            //spawnerQuery.toe
            var newjob= Entities
                .WithNone<TagShouldSpawnBullet>()   
                .WithAll<TagWeapon>()
                .ForEach(
                    ( Entity entity, int entityInQueryIndex, in WeaponData weaponData) =>
                    {
                        if (weaponData.IsFiring == 1)
                        {
                            ecb.AddComponent<TagShouldSpawnBullet>(entityInQueryIndex, entity);
                           //ecb.AddComponent<TagShouldSpawnBullet>();
                            Debug.Log("Fire");
                        }
                        
                    }
                ).ScheduleParallel(this.Dependency);
            
            _endInitializationEntityCommandBufferSystem.AddJobHandleForProducer(newjob);
            this.Dependency = newjob;
            //ecb.AddComponent<TagShouldSpawn>(spawnerQuery);
            //ecb.RemoveComponent<TagShouldSpawn>(spawnerQuery);

        }
    }
}