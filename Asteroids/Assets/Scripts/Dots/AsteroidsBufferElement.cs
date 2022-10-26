using Unity.Entities;

namespace Dots
{
    [InternalBufferCapacity(3)]
    public struct AsteroidsBufferElement : IBufferElementData
    {
        public int Scale;
        public float Speed;
    }
}