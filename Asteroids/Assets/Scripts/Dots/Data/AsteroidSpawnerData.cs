using Unity.Entities;
using UnityEngine;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct AsteroidSpawnerData : IComponentData
    {
        public int AsteroidsToSpawn;
        public int generation;
    }
}