using System;

namespace AlgoVis.Core
{
    public class ActionParameter
    {
        public ActionParameter(string name, Type type, Predicate<object> validator = null)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Validator = validator ?? (x => true);
        }

        public string Name { get; }

        public Type Type { get; }

        public Predicate<object> Validator { get; }
    }
}