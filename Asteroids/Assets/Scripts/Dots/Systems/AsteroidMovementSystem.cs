using Dots.Data;
using Dots.Tags.Actions;
using Dots.Tags.Objects;
using Unity.Entities;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace Dots.Systems
{
    public class AsteroidMovementSystem : SystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Entities
                .WithEntityQueryOptions(EntityQueryOptions.FilterWriteGroup)
                .WithAll<TagAsteroid>()
                .ForEach(
                    (ref PhysicsVelocity velocity, ref SimpleMoveData movementData, in AsteroidData asteroidData
                    ) =>
                    {

                    }
                ).ScheduleParallel();
        }

        protected override void OnUpdate()
        {
            
        }
    }
}
