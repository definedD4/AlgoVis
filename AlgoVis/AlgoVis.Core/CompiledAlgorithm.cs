using System;
using System.Collections.Generic;

namespace AlgoVis.Core
{
    public class CompiledAlgorithm
    {
        public CompiledAlgorithm(string name, string description, IEnumerable<IAction> actions, object display)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (actions == null) throw new ArgumentNullException(nameof(actions));

            Name = name;
            Description = description;
            Actions = new List<IAction>(actions);
            Display = display;
        }

        public string Name { get; }

        public string Description { get; }

        public IEnumerable<IAction> Actions { get; }

        public object Display { get; }
    }
}