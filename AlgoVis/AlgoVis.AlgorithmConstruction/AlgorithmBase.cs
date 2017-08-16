using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AlgoVis.Core;
using AlgoVis.DataModel;

namespace AlgoVis.AlgorithmConstruction
{
    public abstract class AlgorithmBase : ModelHolder
    {
        public CompiledAlgorithm Build()
        {
            Type info = this.GetType();

            var algorithmAttribute =
                info.GetCustomAttributes(typeof(AlgorithmAttribute)).FirstOrDefault() as AlgorithmAttribute;
            if(algorithmAttribute == null) throw new AlgorithmBuildException("Algorithm attribute not found");

            string name = algorithmAttribute.Name;
            string description = algorithmAttribute.Description;

            var actions = new List<IAction>();
            foreach (var methodInfo in info.GetMethods())
            {
                var actionAttribute = methodInfo.GetCustomAttributes(typeof(ActionAttribute)).FirstOrDefault() as ActionAttribute;
                if(actionAttribute == null) continue;

                /*if(!methodInfo.ReturnType.GetInterfaces().Contains(typeof(IEnumerable<IActionStatement>)))
                    throw new AlgorithmBuildException("Action method has invalid return type");*/ // TODO: Fix return type check

                var paramerters = methodInfo.GetCustomAttributes(typeof(ParamAttribute))
                    .Select(attr => attr as ParamAttribute)
                    .Where(attr => attr != null)
                    .Select(attr => new ActionParameter(attr.Name, attr.Type));

                actions.Add(new MethodAction(actionAttribute.Name, actionAttribute.Description, paramerters, this, methodInfo));
            }

            return new CompiledAlgorithm(name, description, actions, Display);
        }

        public abstract object Display { get; }
    }
}