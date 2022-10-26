using Dots.Data;
using Unity.Entities;
using UnityEngine;
using Dots.Tags.Objects;
using Unity.Jobs;
using Utility;

namespace Dots.Systems
{
    [AlwaysSynchronizeSystem]
    public class EngineSystem : JobComponentSystem
    {
        private EntityManager manager;
        protected override void OnCreate()
        {
            base.OnCreate();
            manager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            
            Entities
                .WithAll<TagShip>()
                .WithStructuralChanges()
                .ForEach(
                ( ref ParticleOnPressData engineData,  in InputData inputData) =>
                {
                    var engineActive = inputData.Button1 == 1;
                    var isParticleEnabled = manager.GetEnabled(engineData.ParticleEntity);
                    switch (engineActive)
                    {
                        case true when !isParticleEnabled:
                            manager.SetEnabled(engineData.ParticleEntity, true);
                            break;
                        case false when isParticleEnabled:
                            manager.SetEnabled(engineData.ParticleEntity, false);
                            break;
                    }
                }
            ).Run();
            return default;
        }
    }
}
