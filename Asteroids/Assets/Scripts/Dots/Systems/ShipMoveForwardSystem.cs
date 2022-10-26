using Dots.Data;
using Dots.Systems.Hybrid;
using Dots.Tags.Objects;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

namespace Dots.Systems
{
    [UpdateBefore(typeof(SpawnBulletSystem))]
    [UpdateInGroup(typeof(LateSimulationSystemGroup))]
    [AlwaysSynchronizeSystem]
    public class ShipMoveForwardSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            float time = Time.DeltaTime;
            Entities.WithAll<TagShip>().ForEach(
                (ref PhysicsVelocity physicsVelocity,ref WeaponData weapon, in Rotation rot, in AcceleratedMovementData acceleratedMovementData, in InputData inputData) =>
                {
                    if (inputData.Button1 == 1)
                    {
                        var direction = math.rotate(rot.Value, math.up());
                        weapon.AimDirection = math.normalize(direction);
                        physicsVelocity.Linear += acceleratedMovementData.Acceleration * time * direction;
                    }
                }
            ).Run();
            return default;
        }
    }
}
