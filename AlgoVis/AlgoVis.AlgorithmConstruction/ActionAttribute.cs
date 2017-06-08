using System;

namespace AlgoVis.AlgorithmConstruction
{
    [AttributeUsage(AttributeTargets.Method)]
    sealed class ActionAttribute : Attribute
    {
        public ActionAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }    
    }
}