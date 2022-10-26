using Unity.Entities;
using Unity.Mathematics;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct WeaponData : IComponentData
    {
        public Entity BulletEntity;
        public float Offset;
        public int IsFiring;
        public float3 AimDirection;
        public int ProjectileSpeed;
        
    }
}
