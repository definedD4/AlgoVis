using System;

namespace AlgoVis.Core
{
    public class ActionParameter
    {
        public ActionParameter(string name, Type type)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (type == null) throw new ArgumentNullException(nameof(type));

            Name = name;
            Type = type;
        }

        public string Name { get; }

        public Type Type { get; }
    }
}