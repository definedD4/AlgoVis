using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AlgoVis.Core;

namespace AlgoVis.AlgorithmConstruction
{
    public class MethodAction : IAction
    {
        private readonly AlgorithmBase _algorithm;
        private readonly MethodInfo _method;

        public MethodAction(string name, string description, IEnumerable<ActionParameter> parameters,
            AlgorithmBase algorithm, MethodInfo method)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
            _algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
            _method = method ?? throw new ArgumentNullException(nameof(method));
        }

        public string Name { get; }

        public string Description { get; }

        public IEnumerable<ActionParameter> Parameters { get; }

        public IEnumerable<IActionStatement> Execute(object[] parameters)
        {
            if(!parameters.Zip(Parameters,
                    (parameter, parameterDescription) => parameterDescription.Type.IsInstanceOfType(parameter))
                .All(v => v)) throw new ArgumentException();

            _algorithm.ResetOnLocals();
            _algorithm.ResetMetadata();

            var enumerable = (IEnumerable<IActionStatement>) _method.Invoke(_algorithm, parameters);

            _algorithm.FireOnLocalUpdates();
            foreach (var statement in enumerable)
            {
                yield return statement;
                _algorithm.ResetMetadata();
                _algorithm.FireOnLocalUpdates();
            }
        }
    }
}