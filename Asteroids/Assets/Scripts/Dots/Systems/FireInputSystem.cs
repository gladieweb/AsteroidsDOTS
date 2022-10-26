using Dots.Data;
using Dots.Tags.Objects;
using Unity.Entities;
using Unity.Jobs;
using Utility;


namespace Dots.Systems
{
    [AlwaysSynchronizeSystem]
    public class FireInputSystem : JobComponentSystem
    {
        protected override JobHandle OnUpdate(JobHandle inputDeps)
        {
            Entities
                .WithAll<TagWeapon>()
                .ForEach(
                    ( ref WeaponData weaponData,  in InputData inputData) =>
                    {
                        weaponData.IsFiring = inputData.Button2;
                    }
                ).Run();
            return default;
        }
    }
}