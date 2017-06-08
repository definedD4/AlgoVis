using System;

namespace AlgoVis.AlgorithmConstruction
{
    [AttributeUsage(AttributeTargets.Class)]
    sealed class AlgorithmAttribute : Attribute
    {
        public AlgorithmAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public string Description { get; set; }
    }
}