using Unity.Entities;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct ParticleOnPressData : IComponentData
    {
        public Entity ParticleEntity;
    }
}
