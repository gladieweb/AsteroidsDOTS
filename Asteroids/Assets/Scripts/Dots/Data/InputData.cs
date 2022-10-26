using Unity.Entities;

namespace Dots.Data
{
    [GenerateAuthoringComponent]
    public struct InputData : IComponentData
    {
        public float HorizontalAxisInput;
        public int Button1;
        public int Button2;
        public int Button3;
    }
}

