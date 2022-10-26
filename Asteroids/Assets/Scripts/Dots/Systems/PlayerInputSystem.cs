using Dots.Data;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;
using Utility;

namespace Dots.Systems
{
    [AlwaysSynchronizeSystem]
    public class PlayerInputSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Entities
                .WithoutBurst()
                .ForEach(
                    (ref AcceleratedMovementData shipMovementData, ref InputData shipInputData) =>
                    {
                        shipInputData.HorizontalAxisInput = Input.GetAxisRaw(KeyBindings.HorizontalAxisName);
                        shipInputData.Button1 = Input.GetButton(KeyBindings.ActionButton1) ? 1 : 0;
                        shipInputData.Button2 = Input.GetButton(KeyBindings.ActionButton2) ? 1 : 0;
                    }
                ).Run();
            return default;
        }
    }
}
