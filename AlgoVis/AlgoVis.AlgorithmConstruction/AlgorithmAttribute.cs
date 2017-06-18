using System;

namespace AlgoVis.AlgorithmConstruction
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class AlgorithmAttribute : Attribute
    {
        public AlgorithmAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public string Description { get; set; }
    }
}