using Unity.Entities;
using UnityEngine;

namespace Dots.Systems.Hybrid
{
    public class IntroSystem : SystemBase
    {
        protected override void OnCreate()
        {
            Debug.Log("OnCreate()");
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
        }

        protected override void OnStopRunning()
        {
            base.OnStopRunning();
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}