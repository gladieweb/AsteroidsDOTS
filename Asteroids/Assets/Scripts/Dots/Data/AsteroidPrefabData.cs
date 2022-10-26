using Unity.Entities;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct AsteroidPrefabData : IComponentData
    {
        public Entity buffer;
        public Entity asteroidPrefab0;
        public Entity asteroidPrefab1;
        public Entity asteroidPrefab2;
    }
}
