using System;
using AlgoVis.Core;
using ReactiveUI;
using AlgoVis.UI.AlgorithmActionParam;
using System.Linq;
using System.Reactive.Linq;

namespace AlgoVis.UI.AlgorithmAction
{
    public class AlgorithmActionViewModel : ReactiveObject
    {
        private readonly IAction _action;

        public string Name => _action.Name;

        public string Description => _action.Description;

        public IReactiveCollection<AlgorithmActionParamViewModel> Parameters { get; }

        public ReactiveCommand Execute { get; }

        public AlgorithmActionViewModel(IAction action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));

            Parameters = _action.Parameters
                .CreateDerivedCollection(param => new AlgorithmActionParamViewModel(param));

            var canExecute = Observable.CombineLatest(
                Parameters.Select(p => p.ValidObservable)
                )
                .Select(v => v.All(x => x));

            Execute = ReactiveCommand.Create(() =>
            {
                _action.Execute(Parameters.Select(p => p.Value).ToArray());
            }, canExecute);
        }
    }
}
