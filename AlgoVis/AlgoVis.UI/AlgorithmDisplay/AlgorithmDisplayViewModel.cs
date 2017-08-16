using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Threading;
using AlgoVis.Core;
using AlgoVis.UI.AlgorithmAction;
using ReactiveUI;

namespace AlgoVis.UI.AlgorithmDisplay
{
    public class AlgorithmDisplayViewModel : ReactiveObject
    {
        private readonly CompiledAlgorithm _algorithm;

        private readonly AlgorithmExecutor _executor;

        public string Title => _algorithm.Name;

        public object Display => _algorithm.Display;

        public IReadOnlyList<AlgorithmActionViewModel> Actions { get; }

        public AlgorithmDisplayViewModel(CompiledAlgorithm algorithm)
        {
            _algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));

            _executor = new AlgorithmExecutor(Dispatcher.CurrentDispatcher);

            Actions = _algorithm.Actions.Select(act => new AlgorithmActionViewModel(act)).ToList();

            var actionExecuted = Actions
                .Select(actionViewModel => actionViewModel.Execute)
                .Merge();

            actionExecuted.Subscribe(pack =>
            {
                _executor.Exectue(pack);
            });
        }
    }
}