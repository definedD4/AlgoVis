using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AlgoVis.Core;

namespace AlgoVis.AlgorithmConstruction
{
    public class MethodAction : IAction
    {
        private readonly AlgorithmBase m_Algorithm;
        private readonly MethodInfo m_Method;

        public MethodAction(string name, string description, IEnumerable<ActionParameter> parameters,
            AlgorithmBase algorithm, MethodInfo method)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (description == null) throw new ArgumentNullException(nameof(description));
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            if (algorithm == null) throw new ArgumentNullException(nameof(algorithm));
            if (method == null) throw new ArgumentNullException(nameof(method));

            Name = name;
            Description = description;
            Parameters = parameters;
            m_Algorithm = algorithm;
            m_Method = method;
        }

        public string Name { get; }

        public string Description { get; }

        public IEnumerable<ActionParameter> Parameters { get; }

        public IEnumerable<IActionStatement> Execute(object[] parameters)
        {
            if(!parameters.Zip(Parameters,
                    (parameter, parameterDescription) => parameterDescription.Type.IsInstanceOfType(parameter))
                .All(v => v)) throw new ArgumentException();

            return (IEnumerable<IActionStatement>) m_Method.Invoke(m_Algorithm, parameters);
        }
    }
}