using Dots.Data;
using Dots.Tags.Objects;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

namespace Dots.Systems
{
    [UpdateBefore(typeof(ShipMoveForwardSystem))]
    [AlwaysSynchronizeSystem]
    public class ShipTurnSystem : JobComponentSystem
    {

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            var time = Time.DeltaTime;
            Entities
                .WithAll<TagShip>()
                .ForEach(
                (ref Rotation rotation, ref WeaponData weapon, in AcceleratedMovementData shipMovementData, in InputData inputData) =>
                {
                    rotation.Value = math.mul(rotation.Value, quaternion.Euler(shipMovementData.RotationSpeed * inputData.HorizontalAxisInput * time * math.forward()));
                    var direction = math.rotate(rotation.Value, math.up());
                    weapon.AimDirection = math.normalize(direction);
                }
            ).Run();
            return default;
        }
    }
}