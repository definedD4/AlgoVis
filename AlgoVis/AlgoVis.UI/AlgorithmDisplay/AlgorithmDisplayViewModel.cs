using System;
using System.Collections.Generic;
using System.Linq;
using AlgoVis.Core;
using AlgoVis.UI.AlgorithmAction;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmDisplay
{
    public class AlgorithmDisplayViewModel : ReactiveObject
    {
        private readonly CompiledAlgorithm _algorithm;

        public string Title => _algorithm.Name;

        public object Display => _algorithm.Display;

        public IReadOnlyList<AlgorithmActionViewModel> Actions { get; }

        public AlgorithmDisplayViewModel(CompiledAlgorithm algorithm)
        {
            _algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));

            Actions = _algorithm.Actions.Select(act => new AlgorithmActionViewModel(act)).ToList();
        }
    }
}