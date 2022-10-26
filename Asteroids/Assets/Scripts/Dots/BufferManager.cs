using System;
using Unity.Entities;
using Unity.Rendering;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;
using UnityEngine.Events;
namespace Dots
{
    public class BufferManager : MonoBehaviour , IConvertGameObjectToEntity
    {
        public int[] asteroidsSizes;
        public int[] asteroidsSpeed;
        private DynamicBuffer<AsteroidsBufferElement> _asteroidsBuffer;
        public DynamicBuffer<AsteroidsBufferElement> AsteroidsBuffer => _asteroidsBuffer;

        public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
        {
            _asteroidsBuffer = dstManager.AddBuffer<AsteroidsBufferElement>(entity);
            for (int i = 0; i< asteroidsSizes.Length;i++)
            {
                _asteroidsBuffer.Add( new AsteroidsBufferElement{ Scale = asteroidsSizes[i], Speed = asteroidsSpeed[i]});
            }
            
        }
    }
}