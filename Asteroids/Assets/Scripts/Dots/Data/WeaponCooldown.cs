using Unity.Entities;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct WeaponCooldown : IComponentData
    {
        public float SpawnDelay;
        public float Timer;
    }
}