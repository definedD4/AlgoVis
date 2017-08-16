using System;
using System.Collections.Generic;

namespace AlgoVis.Core
{
    public class ActionExecutePack
    {
        public IAction Action { get; }

        public IReadOnlyList<object> Parameters { get; }

        public ActionExecutePack(IAction action, IReadOnlyList<object> parameters)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }
    }
}