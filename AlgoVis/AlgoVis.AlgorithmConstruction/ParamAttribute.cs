using System;

namespace AlgoVis.AlgorithmConstruction
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class ParamAttribute : Attribute
    {
        public ParamAttribute(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; private set; }

        public Type Type { get; private set; }
    }
}