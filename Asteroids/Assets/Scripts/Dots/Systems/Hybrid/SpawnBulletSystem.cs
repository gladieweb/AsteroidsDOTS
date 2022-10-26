using Dots.Data;
using Dots.Tags.Actions;
using Dots.Tags.Objects;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Utility;

namespace Dots.Systems.Hybrid
{
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    public class SpawnBulletSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _endSimulationEntityCommandBufferSystem;
        protected override void OnCreate()
        {
            base.OnCreate();
            _endSimulationEntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            var ecb = _endSimulationEntityCommandBufferSystem.CreateCommandBuffer().AsParallelWriter();
            var deltaTime = Time.DeltaTime;
            var newJob = Entities
                .WithAll<TagShouldSpawnBullet>()
                .ForEach(
                    (Entity e, int entityInQueryIndex, ref WeaponCooldown spawnerData,in WeaponData weaponData, in Translation translation, in Rotation rot) =>
                    {
                        spawnerData.Timer -= deltaTime;
                        if (!(spawnerData.Timer <= 0)) return;
                        if (weaponData.IsFiring != 1) return;
                        spawnerData.Timer = spawnerData.SpawnDelay;

                        var newEntity = ecb.Instantiate(entityInQueryIndex, weaponData.BulletEntity);
                        var position = translation.Value;
                        // calculate2Dfoward = math.cross(math.forward(rot.Value), math.right());
                        
                        var weaponPosition = position + weaponData.AimDirection * weaponData.Offset;
                        weaponPosition.z = position.z;
                        
                        /*Translation t = translation;
                        var dir = weaponData.AimDirection;
                        dir = math.normalize(dir);*/
                        var shootDir = weaponPosition - position;
                        shootDir = math.normalize(shootDir);
                        //var rot = quaternion.LookRotation(dir, math.up());
                        
                        ecb.SetComponent(entityInQueryIndex, newEntity,
                            new Rotation { Value = rot.Value });
                        
                        ecb.SetComponent(entityInQueryIndex, newEntity,
                            new Translation { Value = weaponPosition });
                        
                        ecb.SetComponent(entityInQueryIndex, newEntity,
                            new SimpleMoveData
                                { Speed = weaponData.ProjectileSpeed, Direction = shootDir });
                        ecb.AddComponent<TagMove>(entityInQueryIndex, newEntity);
                        ecb.RemoveComponent<TagShouldSpawnBullet>(entityInQueryIndex, e);
                    }).ScheduleParallel(this.Dependency);
            _endSimulationEntityCommandBufferSystem.AddJobHandleForProducer(newJob);
            this.Dependency = newJob;
        }
    }
}