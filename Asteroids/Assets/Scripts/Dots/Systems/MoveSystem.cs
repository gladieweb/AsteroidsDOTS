using Dots.Data;
using Dots.Tags.Actions;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Dots.Systems{

[UpdateBefore(typeof(TransformSystemGroup))]
public class MoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float time = Time.DeltaTime;
            
            Entities
                .WithEntityQueryOptions(EntityQueryOptions.FilterWriteGroup)
                .WithAll<TagMove>()
                .ForEach(
                    (ref Translation velocity, ref Rotation rot, in SimpleMoveData movementData) =>
                    {
                        velocity.Value += movementData.Direction * movementData.Speed  * time;
                    }
                ).ScheduleParallel();
        }
        
    }
}
