using Unity.Entities;
using Unity.Mathematics;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct AcceleratedMovementData : IComponentData
    {
        public float Acceleration;
        public float RotationSpeed;
    }
}