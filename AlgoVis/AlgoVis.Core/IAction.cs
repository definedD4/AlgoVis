using System.Collections.Generic;

namespace AlgoVis.Core
{
    public interface IAction
    {
        string Name { get; }

        string Description { get; }

        IEnumerable<ActionParameter> Parameters { get; }

        IEnumerable<IActionStatement> Execute(object[] parameters);
    }
}