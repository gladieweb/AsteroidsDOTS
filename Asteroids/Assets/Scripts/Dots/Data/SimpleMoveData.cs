using Unity.Entities;
using Unity.Mathematics;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct SimpleMoveData : IComponentData
    {
        public float Speed;
        public float3 Direction;
    }
}
