using System;
using AlgoVis.Core;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmAction
{
    public class AlgorithmActionViewModel : ReactiveObject
    {
        private readonly IAction _action;

        public string Name => _action.Name;

        public AlgorithmActionViewModel(IAction action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }
    }
}