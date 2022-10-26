using Unity.Entities;
using Unity.Transforms;

namespace Dots.Tags.Actions
{
    [GenerateAuthoringComponent]
    [WriteGroup(typeof(LocalToWorld))]
    public struct TagStopMove : IComponentData
    {
    }
}