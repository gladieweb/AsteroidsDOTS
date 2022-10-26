using Dots.Data;
using Dots.Systems.Hybrid;
using Dots.Tags.Actions;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

namespace Dots.Systems{
[AlwaysSynchronizeSystem]
[UpdateBefore(typeof(TransformSystemGroup))]
//[UpdateInGroup(typeof(LateSimulationSystemGroup))]
public class MoveSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            float time = Time.DeltaTime;
            Entities
                //.WithEntityQueryOptions(EntityQueryOptions.FilterWriteGroup)
                //.WithAll<TagMove>()
                .ForEach(
                    (ref Translation velocity, ref Rotation rot, in SimpleMoveData movementData
                        ) =>
                    {
                        /*var dir = movementData.Direction;
                        dir.z = 0;
                        dir = math.normalize(dir);
                        rot.Value = quaternion.LookRotation(dir, math.up());*/
                        velocity.Value += movementData.Direction * movementData.Speed  * time;
                        
                        Debug.Log("flying");
                    }
                ).Run();
        }
    }
}
